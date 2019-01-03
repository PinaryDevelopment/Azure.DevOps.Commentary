namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Git
{
    public class GitRepositoryRef
    {
        public TeamProjectCollectionReference Collection { get; set; }
        public string Id { get; set; }
        public bool IsFork { get; set; }
        public string Name { get; set; }
        public TeamProjectReference Project { get; set; }
        public string RemoteUrl { get; set; }
        public string SshUrl { get; set; }
        public string Url { get; set; }

    }
}
