using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
namespace WeatherAPI.Services
{
    public class WeatherApiClientService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string? _geocodingUrl;
        private readonly string? _openWeatherUrl;


        public WeatherApiClientService(HttpClient httpClient,IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = Environment.GetEnvironmentVariable("OPENWEATHER_API_KEY")
                ?? throw new InvalidOperationException("API ključ nije postavljen");

            _geocodingUrl = configuration.GetValue<string>("OpenWeatherApi:GeocodingUrl");
            _openWeatherUrl = configuration.GetValue<string>("OpenWeatherApi:OpenWeatherUrl");
        }

        public async Task<string> GetCityDataAsync(string cityName)
        {
            var url = $"{_geocodingUrl}direct?q={cityName}&limit=5&appid={_apiKey}";
            return await _httpClient.GetStringAsync(url);
        }

        public async Task<string> GetCityWeatherDataAsync(double lat, double lon)
        {
            var url = $"{_openWeatherUrl}weather?lat={lat}&lon={lon}&appid={_apiKey}&units=metric";
            return await _httpClient.GetStringAsync(url);
        }

        public async Task<string> GetCityFiveDayForecastAsync(double lat, double lon)
        {
            var url = $"{_openWeatherUrl}forecast?lat={lat}&lon={lon}&appid={_apiKey}&units=metric";
            return await _httpClient.GetStringAsync(url);
        }
    }
}
