namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public static class CommentCreator
    {
        [FunctionName("CommentCreator")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var comment = await new CommentMapper().Map(req).ConfigureAwait(false);

            await new AzureDevOpsClientWrapper().CreatePostComment(comment).ConfigureAwait(false);

            return new OkResult();
        }
    }
}
