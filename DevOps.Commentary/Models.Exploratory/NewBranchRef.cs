namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Exploratory
{
    public class NewBranchRef
    {
        public string Name { get; set; }
        public string NewObjectId { get; set; } // object id of master branch
        public string OldObjectId => "0000000000000000000000000000000000000000"; // blank object id

        public NewBranchRef(string name, string newObjectId)
        {
            Name = name;
            NewObjectId = newObjectId;
        }
    }
}
