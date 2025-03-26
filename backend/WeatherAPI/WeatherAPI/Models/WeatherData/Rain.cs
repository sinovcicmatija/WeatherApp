using System.Text.Json.Serialization;

namespace WeatherAPI.Models.WeatherData
{
    public class Rain
    {
        [JsonPropertyName("1h")]
        public double? LastHour { get; set; }

        [JsonPropertyName("3h")]
        public double? LastThreehours { get; set; }

    }
}
