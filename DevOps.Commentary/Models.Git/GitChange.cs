namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Git
{
    using PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Exploratory;

    public class GitChange
    {
        //public long ChangeId { get; set; }
        public VersionControlChangeType ChangeType { get; set; }
        //public string Item { get; set; }
        public CommitItem Item { get; set; }
        public ItemContent NewContent { get; set; }
        //public GitTemplate NewContentTemplate { get; set; }
        //public string OriginalPath { get; set; }
        //public string SourceServerItem { get; set; }
        //public string Url { get; set; }
    }
}
