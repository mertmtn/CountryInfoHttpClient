using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CountryInfo.Core.HttpClients
{
    public class DateHttpClient : HttpClientBase
    {
        private HttpClient _httpClient { get; }
        private IConfiguration _configuration { get; }

        public DateHttpClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            httpClient.BaseAddress = new Uri(_configuration.GetSection("DateApiInfo").GetSection("BaseUrl").Value);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public Task<string> GetAsync(string url)
        {
            return HttpClientGetAsync(url, _httpClient);
        }
    }
}
