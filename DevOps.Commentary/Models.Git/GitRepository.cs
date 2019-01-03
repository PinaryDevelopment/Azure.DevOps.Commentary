namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Git
{
    public class GitRepository
    {
        public ReferenceLinks _links { get; set; }
        public string DefaultBranch { get; set; }
        public string Id { get; set; }
        public bool IsFork { get; set; }
        public string Name { get; set; }
        public GitRepositoryRef ParentRepository { get; set; }
        public TeamProjectReference Project { get; set; }
        public string RemoteUrl { get; set; }
        public long Size { get; set; }
        public string SshUrl{ get; set; }
        public string Url { get; set; }
        public string[] ValidRemoteUrls { get; set; }
    }
}
