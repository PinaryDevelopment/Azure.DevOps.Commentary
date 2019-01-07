namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Git
{
    public class FileContentMetadata
    {
        public string ContentType { get; set; }
        public int Encoding { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }
        public bool IsBinary { get; set; }
        public bool IsImage { get; set; }
        public string VsLink { get; set; }
    }
}
