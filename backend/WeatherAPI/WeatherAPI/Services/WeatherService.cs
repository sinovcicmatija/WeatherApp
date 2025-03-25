using System.Text.Json;
using WeatherAPI.Helpers;
using WeatherAPI.Interfaces;
using WeatherAPI.Models.WeatherData;
using WeatherAPI.Models;

namespace WeatherAPI.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherApiClientService _apiClient;
        private readonly ILogger<WeatherService> _logger;
        private readonly IRedisCacheService _redisCache;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(10);

        public WeatherService(ILogger<WeatherService> logger, WeatherApiClientService apiClient, IRedisCacheService redisCache)
        {
            _apiClient = apiClient;
            _logger = logger;
            _redisCache = redisCache;
        }

        public async Task<WeatherData?> GetCityWeatherDataAsync(CityItem city)
        {
            string cityKey = "selectedCity";
            string weatherKey = $"weather:{city.Lat}:{city.Lon}";

            var cachedCity = await _redisCache.GetAsync<CityItem>(cityKey);

            if (cachedCity != null && cachedCity.Lat == city.Lat && cachedCity.Lon == city.Lon)
            {
                var cachedWeatherData = await _redisCache.GetAsync<WeatherData>(weatherKey);
                if (cachedWeatherData != null)
                {
                    _logger.LogInformation($"Vraćam keširane podatke za {city.Lat}, {city.Lon}");
                    return cachedWeatherData;
                }
            } else
            {
                _logger.LogInformation($"Novi grad odabran, dohvaćam API podatke...");
            }
            var response = await _apiClient.GetCityWeatherDataAsync(city.Lat, city.Lon);
            var weatherData = JsonSerializer.Deserialize<WeatherData>(response);

            if(weatherData != null && weatherData.Sys != null)
            {
                weatherData.Sys.SunriseLocalTime = TimeConversionHelper.ConvertToLocalTime(weatherData.Sys.Sunrise, weatherData.Timezone);
                weatherData.Sys.SunsetLocalTime = TimeConversionHelper.ConvertToLocalTime(weatherData.Sys.Sunset, weatherData.Timezone);
            }

            await _redisCache.SetAsync(cityKey, city, TimeSpan.FromDays(1));
            await _redisCache.SetAsync(weatherKey, weatherData, TimeSpan.FromMinutes(10));

            _logger.LogInformation($"Podaci spremljeni u Redis za {city.Lat}, {city.Lon}");


            return weatherData;
        }
    }
}
