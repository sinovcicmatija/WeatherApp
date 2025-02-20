using WeatherAPI.Models;
using WeatherAPI.Models.WeatherData;

namespace WeatherAPI.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherData?> GetCityWeatherDataAsync(double lat, double lon);
    }
}
