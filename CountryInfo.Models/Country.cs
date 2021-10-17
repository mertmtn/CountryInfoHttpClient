using System.Text.Json.Serialization;

namespace CountryInfo.Models
{
    public class Country
    {
        [JsonPropertyName("countryCode")]
        public string Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
