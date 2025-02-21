using System.Text.Json;
using WeatherAPI.Interfaces;
using WeatherAPI.Models;

namespace WeatherAPI.Services
{
    public class CityService : ICityService
    {
        private readonly WeatherApiClientService _apiClient;

        public CityService(WeatherApiClientService apiClient) 
        {
            _apiClient = apiClient;
        }

        public async Task<List<CityItem>> GetCityCoordinatesAsync(string cityName)
        {
            var response = await _apiClient.GetCityDataAsync(cityName);
            Console.WriteLine(response);

            var cities = JsonSerializer.Deserialize<List<CityItem>>(response);
            return cities ?? new List<CityItem>();
        }
    }
}
