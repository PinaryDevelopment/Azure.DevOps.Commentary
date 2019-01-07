namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Git
{
    public class GitItem
    {
        public ReferenceLinks _links { get; set; }
        public string CommitId { get; set; }
        public string Content { get; set; }
        public FileContentMetadata ContentMetadata { get; set; }
        public GitObjectType GitObjectType { get; set; }
        public bool IsFolder { get; set; }
        public bool IsSymLink { get; set; }
        public GitCommitRef LatestProcessedChange { get; set; }
        public string ObjectId { get; set; }
        public string OriginalObjectId { get; set; }
        public string Path { get; set; }
        public string Url { get; set; }
    }
}
