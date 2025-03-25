using System.Text.Json.Serialization;

namespace WeatherAPI.Models.WeatherData
{
    public class Rain
    {
        [JsonPropertyName("1h")]
        public double? LastHour { get; set; }
    }
}
