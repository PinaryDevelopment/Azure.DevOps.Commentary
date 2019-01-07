namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator
{
    using PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Exploratory;
    using PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Git;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    public class AzureDevOpsClientWrapper
    {
        private HttpClient HttpClient { get; set; }

        private string BaseUrl { get; }

        private string ApiVersionQueryParameter => "api-version=5.1-preview.1";

        public AzureDevOpsClientWrapper()
        {
            var organization = Environment.GetEnvironmentVariable("Organization");
            var projectName = Environment.GetEnvironmentVariable("ProjectName");
            var repositoryId = Environment.GetEnvironmentVariable("RepositoryId");

            BaseUrl = $"https://dev.azure.com/{organization}/{projectName}/_apis/git/repositories/{repositoryId}/";
        }

        public async Task CreatePostComment(PostComment comment)
        {
            using (var client = new HttpClient())
            {
                var userName = Environment.GetEnvironmentVariable("LocalUserName");
                var personalAccessToken = Environment.GetEnvironmentVariable("PersonalAccessToken");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{userName}:{personalAccessToken}")));
                HttpClient = client;

                var masterBranch = await GetMasterBranch().ConfigureAwait(false);
                var commentBranch = await CreateCommentBranch(masterBranch).ConfigureAwait(false);
                await CreatePush(comment, masterBranch.ObjectId, commentBranch.Name).ConfigureAwait(false);
                await CreatePullRequest(masterBranch.Name, commentBranch.Name).ConfigureAwait(false);
            }
        }

        private async Task<GitRef> GetMasterBranch()
        {
            return (await HttpClient.GetWithResponse<RefSet<GitRef>>($"{BaseUrl}refs?filter=heads/master&peelTags=true&{ApiVersionQueryParameter}").ConfigureAwait(false)).Value[0];
        }

        private async Task<NewRef> CreateCommentBranch(GitRef masterBranch)
        {
            var newBranchName = $"refs/heads/{Guid.NewGuid()}";
            return (await HttpClient.PostWithResponse<NewBranchRef[], RefSet<NewRef>>($"{BaseUrl}refs?{ApiVersionQueryParameter}", new[] { new NewBranchRef(newBranchName, masterBranch.ObjectId) }).ConfigureAwait(false)).Value[0];
        }

        private async Task<GitPush> CreatePush(PostComment comment, string masterBranchObjectId, string newBranchName)
        {
            var newPush = new CreatePushRequestBody
            {
                Commits = new[]
                {
                    new GitCommitRef
                    {
                        Changes = await CreateChanges(comment).ConfigureAwait(false),
                        Comment = "new comment"
                    }
                },
                RefUpdates = new[]
                {
                    new GitRefUpdate
                    {
                        Name = newBranchName,
                        OldObjectId = masterBranchObjectId
                    }
                }
            };

            return await HttpClient.PostWithResponse<CreatePushRequestBody, GitPush>($"{BaseUrl}pushes?api-version=5.1-preview.2", newPush).ConfigureAwait(false);
        }

        private async Task<GitChange[]> CreateChanges(PostComment comment)
        {
            return CreateAttachmentAdds(comment.Attachments)
                .Append(await CreatePostUpdate(comment).ConfigureAwait(false))
                .ToArray();
        }

        private async Task<GitChange> CreatePostUpdate(PostComment comment)
        {
            var item = await HttpClient.GetFileContents($"{BaseUrl}items?path={comment.FilePath}&{ApiVersionQueryParameter}").ConfigureAwait(false);
            item = $"{item}\n{comment.Comment}";
            return new GitChange
            {
                ChangeType = VersionControlChangeType.Edit,
                Item = new CommitItem
                {
                    Path = comment.FilePath
                },
                NewContent = new ItemContent
                {
                    Content = item
                }
            };
        }

        private IEnumerable<GitChange> CreateAttachmentAdds(Attachment[] attachments)
        {
            return attachments.Select(attachment => new GitChange
            {
                ChangeType = VersionControlChangeType.Add,
                Item = new CommitItem
                {
                    Path = $"Client/src/assets/comments/{attachment.FileName}"
                },
                NewContent = new ItemContent
                {
                    Content = attachment.Base64EncodedContent,
                    ContentType = ItemContentType.Base64Encoded
                }
            });
        }

        private Task<GitPullRequest> CreatePullRequest(string masterBranchName, string newBranchName)
        {
            var newPullRequest = new CreatePullRequestBody
            {
                SourceRefName = newBranchName,
                TargetRefName = masterBranchName,
                Title = "new comment for review"
            };

            return HttpClient.PostWithResponse<CreatePullRequestBody, GitPullRequest>($"{BaseUrl}pullrequests?{ApiVersionQueryParameter}", newPullRequest);
        }
    }
}
