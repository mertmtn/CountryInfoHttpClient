using System.Text.Json.Serialization;

namespace CountryInfo.Models
{
    public class Holiday
    {
        [JsonPropertyName("date")]        
        public string Date { get; set; }

        [JsonPropertyName("localName")]
        public string LocalName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }       

        [JsonPropertyName("global")]
        public bool Global { get; set; }     

        [JsonPropertyName("launchYear")]
        public object LaunchYear { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
