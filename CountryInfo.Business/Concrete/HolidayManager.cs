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
    public class HolidayManager : IHolidayService
    {
        private DateApiInfo _dateApiInfoOptions;
        private DateHttpClient _dateHttpClient;
        public HolidayManager(DateHttpClient dateHttpClient, IOptions<DateApiInfo> dateApiInfoOptions)
        {
            _dateApiInfoOptions = dateApiInfoOptions.Value;
            _dateHttpClient = dateHttpClient;
        }

        public async Task<List<Holiday>> GetYearlyHolidayByCountry(string countryCode, int Year)
        {
            var apiUrl = _dateApiInfoOptions.DateApiMethodLink.PublicHolidays;
            var responseString = await _dateHttpClient.GetAsync(apiUrl.Replace("{countryCode}", countryCode).Replace("{year}", Year.ToString()));
            var list = JsonSerializer.Deserialize<List<Holiday>>(responseString);
            return list;
        }
    }
}
