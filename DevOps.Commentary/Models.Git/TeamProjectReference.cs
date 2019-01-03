namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Git
{
    public class TeamProjectReference
    {
        public string Abbreviation { get; set; }
        public string DefaultTeamImageUrl { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public long Revision { get; set; }
        // public ProjectState State{ get; set; } // ? enum
        public string Url { get; set; }
        // public ProjectVisibility Visibility { get; set; } // ? enum
    }
}
