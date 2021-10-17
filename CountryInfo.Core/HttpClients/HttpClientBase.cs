using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CountryInfo.Core.HttpClients
{
    public class HttpClientBase
    {
        public async Task<string> HttpClientPostAsync<TRequest>(string url, HttpClient client, TRequest request)
        {
            var body = JsonSerializer.Serialize(request); 
            var httpResponse = await client.PostAsync(url, new StringContent(body, Encoding.UTF8, "application/json"));
            httpResponse.EnsureSuccessStatusCode();
            var responseData = await httpResponse.Content.ReadAsStringAsync();
            return responseData;
        }
        protected async Task<string> HttpClientGetAsync(string url, HttpClient client)
        { 
            var httpResponse = await client.GetAsync(url);
            httpResponse.EnsureSuccessStatusCode();
            var responseData = await httpResponse.Content.ReadAsStringAsync();
            return responseData;
        }
    }
}
