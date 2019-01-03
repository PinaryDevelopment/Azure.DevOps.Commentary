namespace PinaryDevelopment.Utilities.External.AzureDevOps.CommentCreator
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public static class HttpClientExtensions
    {
        public static async Task<T> GetWithResponse<T>(this HttpClient client, string url)
        {
            using (var response = await client.GetAsync(url).ConfigureAwait(false))
            {
                // var str = await response.Content.ReadAsStringAsync().ConfigureAwait(false); // for debugging purposes
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<T>().ConfigureAwait(false);
            }
        }

        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
            Formatting = Formatting.None
        };

        public static async Task<TResponse> PostWithResponse<TBody, TResponse>(this HttpClient client, string url, TBody body)
        {
            var json = JsonConvert.SerializeObject(body, JsonSerializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(url, content).ConfigureAwait(false))
            {
                // var str = await response.Content.ReadAsStringAsync().ConfigureAwait(false); // for debugging purposes
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<TResponse>().ConfigureAwait(false);
            }
        }
    }
}
