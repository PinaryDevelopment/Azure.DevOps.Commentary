namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator
{
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator.Models.Exploratory;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class CommentMapper
    {
        public async Task<PostComment> Map(HttpRequest request)
        {
            if (request.ContentType == "application/json")
            {
                return await MapJsonComment(request).ConfigureAwait(false);
            }

            if (request.ContentType.StartsWith("multipart/form-data"))
            {
                return await MapFormComment(request).ConfigureAwait(false);
            }

            throw new NotImplementedException($"No mapping created yet for request content type: {request.ContentType}");
        }

        private async Task<PostComment> MapJsonComment(HttpRequest request)
        {
            var requestBody = await new StreamReader(request.Body).ReadToEndAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PostComment>(requestBody);
        }

        private async Task<PostComment> MapFormComment(HttpRequest request)
        {
            var formKeyValuePairs = await request.ReadFormAsync().ConfigureAwait(false);
            var formDictionary = JsonConvert.SerializeObject(formKeyValuePairs.ToDictionary(kv => kv.Key[0].ToString().ToUpperInvariant() + kv.Key.Substring(1), kv => kv.Value[0]));
            var newComment = JsonConvert.DeserializeObject<PostComment>(formDictionary);

            if (formKeyValuePairs.Files.Count > 0)
            {
                newComment.Attachments = new Attachment[formKeyValuePairs.Count];
                for (var i = 0; i < formKeyValuePairs.Count; i++)
                {
                    var file = formKeyValuePairs.Files[i];
                    newComment.Attachments[i] = await CreateAttachement(file).ConfigureAwait(false);
                }
            }

            return newComment;
        }

        private static async Task<Attachment> CreateAttachement(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream).ConfigureAwait(false);
                return new Attachment
                {
                    FileName = file.FileName,
                    Base64EncodedContent = Convert.ToBase64String(memoryStream.ToArray())
                };
            }
        }
    }
}
