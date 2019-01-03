namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Git
{
    public class GitPushRef
    {
        public ReferenceLinks _links { get; set; }
        public string Date { get; set; }
        public long PushId { get; set; }
        public IdentityRef PushedBy { get; set; }
        public string Url { get; set; }
    }
}
