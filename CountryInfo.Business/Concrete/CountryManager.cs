using CountryInfo.Business.Abstract;
using CountryInfo.Core.HttpClients;
using CountryInfo.Core.Options;
using CountryInfo.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace CountryInfo.Business.Concrete
{
    public class CountryManager : ICountryService
    {
        private DateApiInfo _dateApiInfoOptions;
        private DateHttpClient _dateHttpClient;
        public CountryManager(DateHttpClient dateHttpClient, IOptions<DateApiInfo> dateApiInfoOptions)
        {
            _dateApiInfoOptions = dateApiInfoOptions.Value;
            _dateHttpClient = dateHttpClient;
        }

        public async Task<List<Country>> GetAllCountry()
        {
            var apiUrl = _dateApiInfoOptions.DateApiMethodLink.AvailableCountries;
            var responseString = await _dateHttpClient.GetAsync(apiUrl);
            var list = JsonSerializer.Deserialize<List<Country>>(responseString);
            return list;
        }
    }
}
