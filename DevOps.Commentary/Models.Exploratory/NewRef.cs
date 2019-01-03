namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Exploratory
{
    public class NewRef
    {
        public string RepositoryId { get; set; }
        public string Name { get; set; }
        public string OldObjectId { get; set; }
        public string NewObjectId { get; set; }
        public bool IsLocked { get; set; }
        public string UpdateStatus { get; set; }
        public bool Success { get; set; }
    }
}
