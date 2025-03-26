using System.Text.Json.Serialization;
using WeatherAPI.Models.WeatherData;

namespace WeatherAPI.Models
{
    public class FiveDayForecast
    {
        [JsonPropertyName("cnt")]
        public int Cnt { get; set; }

        [JsonPropertyName("list")]
        public List<WeatherData.WeatherData>? ForecastItems { get; set; }



    }
}
