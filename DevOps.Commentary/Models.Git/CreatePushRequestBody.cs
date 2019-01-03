namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Git
{
    public class CreatePushRequestBody
    {
        //public ReferenceLinks _links { get; set; }
        public GitCommitRef[] Commits { get; set; }
        //public string Date { get; set; }
        //public long PushId { get; set; }
        //public IdentityRef PushedBy { get; set; }
        public GitRefUpdate[] RefUpdates { get; set; }
        //public GitRepository Repository { get; set; }
        //public string Url { get; set; }
    }
}
