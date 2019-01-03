namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Git
{
    public class GitStatus
    {
        public ReferenceLinks _links { get; set; }
        public GitStatusContext Context { get; set; }
        public IdentityRef CreatedBy { get; set; }
        public string CreationDate { get; set; }
        public string Description { get; set; }
        public long Id { get; set; }
        public GitStatusState State { get; set; }
        public string TargetUrl { get; set; }
        public string UpdatedDate { get; set; }
    }
}
