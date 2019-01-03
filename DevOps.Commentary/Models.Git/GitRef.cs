namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Git
{
    public class GitRef
    {
        public ReferenceLinks _links { get; set; }
        public IdentityRef Creator { get; set; }
        public bool IsLocked { get; set; }
        public IdentityRef IsLockedBy { get; set; }
        public string Name { get; set; }
        public string ObjectId { get; set; }
        public string PeeledObjectId { get; set; }
        public GitStatus[] Statuses { get; set; }
        public string Url { get; set; }
    }
}
