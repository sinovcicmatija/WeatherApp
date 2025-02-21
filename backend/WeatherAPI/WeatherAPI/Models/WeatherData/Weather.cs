using System.Text.Json.Serialization;

namespace WeatherAPI.Models.WeatherData
{
    public class Weather
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }
    }
}
