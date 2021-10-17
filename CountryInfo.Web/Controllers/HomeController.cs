using CountryInfo.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CountryInfo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IHolidayService _holidayService;
        public HomeController(ICountryService countryService, IHolidayService holidayService)
        {
            _countryService = countryService;
            _holidayService = holidayService;
        }

        public IActionResult Index()
        { 
            return View();
        }

        public JsonResult GetCountries()
        {
            var countryList = _countryService.GetAllCountry().GetAwaiter().GetResult();
            return Json(countryList);
        }

        public JsonResult GetYearlyHolidayByCountry(string countryCode,int year)
        {
            var countryList = _holidayService.GetYearlyHolidayByCountry(countryCode, year).GetAwaiter().GetResult();
            return Json(countryList);
        }
    }
}
