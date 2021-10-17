 namespace CountryInfo.Core.Options
{
    public class DateApiInfo
    {
        public DateApiInfo()
        {
            DateApiMethodLink = new DateApiMethodLink();
        }
        public string BaseUrl { get; set; }
        public string HttpClientName { get; set; }
        public DateApiMethodLink DateApiMethodLink { get; set; }
    }

    public class DateApiMethodLink
    {
        public string AvailableCountries { get; set; }
        public string PublicHolidays { get; set; }
    }
}
