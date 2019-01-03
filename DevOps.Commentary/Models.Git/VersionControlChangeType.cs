namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Git
{
    // https://docs.microsoft.com/en-us/rest/api/azure/devops/git/pushes/create?view=azure-devops-rest-5.1#versioncontrolchangetype
    public enum VersionControlChangeType
    {
        Add = 1,
        Edit = 2
        /*
         * all
         * branch
         * delete
         * encoding
         * lock
         * merge
         * none
         * property
         * rename
         * rollback
         * sourceRename
         * targetRename
         * undelete
         */
    }
}
