using System.Text.Json.Serialization;

namespace WeatherAPI.Models.WeatherData
{
    public class SysInfo
    {
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("sunrise")]
        public long? Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public long? Sunset { get; set; }

        public DateTime? SunriseLocalTime { get; set; }
        public DateTime? SunsetLocalTime { get; set; }

        /// <summary>
        /// Ovo svojstvo je jedino potrebno 5 day forecast api-u, ostali podaci su korišteni za current weather api, radi jednostavnosti su podaci skupa grupirani
        /// </summary>

        [JsonPropertyName("pod")]
        public string? Pod { get; set; }

    }
}
