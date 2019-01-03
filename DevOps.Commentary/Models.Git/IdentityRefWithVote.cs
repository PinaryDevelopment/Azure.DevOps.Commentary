namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Git
{
    public class IdentityRefWithVote
    {
        public ReferenceLinks _links { get; set; }
        public string Descriptor { get; set; }
        public string DirectoryAlias { get; set; }
        public string DisplayName { get; set; }
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public bool Inactive { get; set; }
        public bool IsAadIdentity { get; set; }
        public bool IsContainer { get; set; }
        public bool IsDeletedInOrigin { get; set; }
        public bool IsRequired { get; set; }
        public string PorfileUrl { get; set; }
        public string ReviewerUrl { get; set; }
        public string UniqueName { get; set; }
        public string Url { get; set; }
        public int Vote { get; set; }
        public IdentityRefWithVote VotedFor { get; set; }
    }
}
