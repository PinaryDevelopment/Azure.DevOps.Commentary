namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Git
{
    public class GitCommitRef
    {
        //public ReferenceLinks _links { get; set; }
        //public GitUserDate Author { get; set; }
        //// public ChangeCountDictionary ChangeCounts { get; set; } // ?IDictionary<string, string>
        public GitChange[] Changes { get; set; }
        public string Comment { get; set; }
        //public bool CommentTruncated { get; set; }
        //public string CommitId { get; set; }
        //public GitUserDate Committer { get; set; }
        //public string[] Parents { get; set; }
        //public GitPushRef Push { get; set; }
        //public string RemoteUrl { get; set; }
        //public GitStatus[] Statuses { get; set; }
        //public string Url { get; set; }
        //public ResourceRef[] WorkItems { get; set; }
    }
}
