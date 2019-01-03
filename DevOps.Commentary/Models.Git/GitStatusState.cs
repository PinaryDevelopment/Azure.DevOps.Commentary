namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Git
{
    public class GitStatusState
    {
        public string Error { get; set; }
        public string Failed { get; set; }
        public string NotApplicable { get; set; }
        public string NotSet { get; set; }
        public string Pending { get; set; }
        public string Succeeded { get; set; }
    }
}
