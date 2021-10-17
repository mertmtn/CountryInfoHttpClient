using CountryInfo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountryInfo.Business.Abstract
{
    public interface IHolidayService
    {
        Task<List<Holiday>> GetYearlyHolidayByCountry(string countryCode, int Year);
    }
}
