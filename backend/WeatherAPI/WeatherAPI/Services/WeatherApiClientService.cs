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


        public WeatherApiClientService(HttpClient httpClient,IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = Environment.GetEnvironmentVariable("OPENWEATHER_API_KEY")
                ?? throw new InvalidOperationException("API ključ nije postavljen");

            _geocodingUrl = configuration.GetValue<string>("OpenWeatherApi:GeocodingUrl");
        }

        public async Task<string> GetCityDataAsync(string cityName)
        {
            var url = $"{_geocodingUrl}direct?q={cityName}&limit=5&appid={_apiKey}";
            return await _httpClient.GetStringAsync(url);
        }
    }
}
