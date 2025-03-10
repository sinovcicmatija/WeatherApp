using Microsoft.Extensions.Logging;
using System.Text.Json;
using WeatherAPI.Interfaces;
using WeatherAPI.Models.WeatherData;

namespace WeatherAPI.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherApiClientService _apiClient;
        private readonly ILogger<WeatherService> _logger;

        public WeatherService(ILogger<WeatherService> logger, WeatherApiClientService apiClient)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        public async Task<WeatherData?> GetCityWeatherDataAsync(double lat, double lon)
        {
            var response = await _apiClient.GetCityWeatherDataAsync(lat, lon);
            Console.Write(response);

            _logger.LogInformation("RAW JSON RESPONSE: {Response}", response);

            var weatherData = JsonSerializer.Deserialize<WeatherData>(response);
            return weatherData;
        }
        public string GetWindDirection(int deg)
        {
            if (deg >= 337.5 || deg <= 22.5) return "N";
            if (deg >= 22.5 && deg < 67.5) return "NE"; 
            if (deg >= 67.5 && deg < 112.5) return "E";   
            if (deg >= 112.5 && deg < 157.5) return "SE"; 
            if (deg >= 157.5 && deg < 202.5) return "S";   
            if (deg >= 202.5 && deg < 247.5) return "SW"; 
            if (deg >= 247.5 && deg < 292.5) return "W"; 
            if (deg >= 292.5 && deg < 337.5) return "NW"; 
            return "Unknown";
        }
    }
}
