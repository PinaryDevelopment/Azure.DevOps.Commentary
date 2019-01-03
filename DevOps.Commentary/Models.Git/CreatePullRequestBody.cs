namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Git
{
    public class CreatePullRequestBody
    {
        public ReferenceLinks _links { get; set; }
        public string ArtifactId { get; set; }
        public IdentityRef AutoCompleteSetBy { get; set; }
        public IdentityRef ClosedBy { get; set; }
        public string ClosedDate { get; set; }
        public long CodeReviewId { get; set; }
        public GitCommitRef[] Commits { get; set; }
        public GitPullRequestCompletionOptions CompletionOptions { get; set; }
        public string CompletionQueueTime { get; set; }
        public IdentityRef CreatedBy { get; set; }
        public string CreationDate { get; set; }
        public string Description { get; set; }
        public GitForkRef ForkSource { get; set; }
        public bool IsDraft { get; set; }
        public WebApiTagDefinition[] Labels { get; set; }
        public GitCommitRef LastMergeCommit { get; set; }
        public GitCommitRef LastMergeSourceCommit { get; set; }
        public GitCommitRef LastMergeTargetCommit { get; set; }
        public string MergeFailureMessage { get; set; }
        // public PullRequestMergeFailureType MergeFailureType { get; set; } // ? enum
        public string MergeId { get; set; }
        public GitPullRequestMergeOptions MergeOptions { get; set; }
        // public PullRequestAsyncStatus MergeStatus { get; set; } // ? enum
        public long PullRequestId { get; set; }
        public string RemoteUrl { get; set; }
        public GitRepository Repository { get; set; }
        public IdentityRefWithVote[] Reviewers { get; set; }
        public string SourceRefName { get; set; }
        public bool SupportsIterations { get; set; }
        public string TargetRefName { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public ResourceRef[] WorkItemRefs { get; set; }
    }
}
