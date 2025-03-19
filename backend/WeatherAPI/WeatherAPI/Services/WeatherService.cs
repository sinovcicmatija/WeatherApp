using System.Text.Json;
using WeatherAPI.Helpers;
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

            if(weatherData != null && weatherData.Sys != null)
            {
                weatherData.Sys.SunriseLocalTime = TimeConversionHelper.ConvertToLocalTime(weatherData.Sys.Sunrise, weatherData.Timezone);
                weatherData.Sys.SunsetLocalTime = TimeConversionHelper.ConvertToLocalTime(weatherData.Sys.Sunset, weatherData.Timezone);

            }
            return weatherData;
        }
    }
}
