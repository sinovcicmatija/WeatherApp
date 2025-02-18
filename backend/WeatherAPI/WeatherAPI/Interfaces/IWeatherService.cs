using WeatherAPI.Models;
using WeatherAPI.Models.WeatherData;

namespace WeatherAPI.Interfaces
{
    public interface IWeatherService
    {
        Task<List<WeatherData>> GetCityWeatherDataAsync(double lat, double lon);
    }
}
