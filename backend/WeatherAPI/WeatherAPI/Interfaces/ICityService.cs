using WeatherAPI.Models;

namespace WeatherAPI.Interfaces
{
    public interface ICityService
    {
        Task<List<CityItem>> GetCityCoordinatesAsync(string cityName);
    }
}