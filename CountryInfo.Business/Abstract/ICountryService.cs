using CountryInfo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountryInfo.Business.Abstract
{
    public interface ICountryService
    {
        Task<List<Country>> GetAllCountry();
    }
}
