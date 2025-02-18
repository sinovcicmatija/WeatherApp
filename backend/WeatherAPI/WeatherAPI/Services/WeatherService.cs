using System.Text.Json;
using WeatherAPI.Interfaces;
using WeatherAPI.Models.WeatherData;

namespace WeatherAPI.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherApiClientService _apiClient;

        public WeatherService(WeatherApiClientService apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<WeatherData>> GetCityWeatherDataAsync(double lat, double lon)
        {
            var response = await _apiClient.GetCityWeatherDataAsync(lat, lon);
            Console.Write(response);

            var weatherData = JsonSerializer.Deserialize<List<WeatherData>>(response);
            return weatherData ?? new List<WeatherData>();
        }
        public string GetWindDirection(int deg)
        {
            if (deg >= 337.5 || deg <= 22.5) return "North";
            if (deg >= 22.5 && deg < 67.5) return "Northeast"; 
            if (deg >= 67.5 && deg < 112.5) return "East";   
            if (deg >= 112.5 && deg < 157.5) return "Southeast"; 
            if (deg >= 157.5 && deg < 202.5) return "South";   
            if (deg >= 202.5 && deg < 247.5) return "Southwest"; 
            if (deg >= 247.5 && deg < 292.5) return "West"; 
            if (deg >= 292.5 && deg < 337.5) return "Northwest"; 
            return "Unknown";
        }
    }
}
