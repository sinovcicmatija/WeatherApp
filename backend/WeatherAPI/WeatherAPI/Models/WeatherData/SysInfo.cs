﻿using System.Text.Json.Serialization;

namespace WeatherAPI.Models.WeatherData
{
    public class SysInfo
    {
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("sunrise")]
        public long Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public long Sunset { get; set; }

        public DateTime SunriseLocalTime { get; set; }
        public DateTime SunsetLocalTime { get; set; }

    }
}
