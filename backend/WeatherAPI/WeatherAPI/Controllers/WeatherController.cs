using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Interfaces;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {

        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }


        [HttpGet]
        [Route("cityWeather")]

        public async Task<IActionResult> GetWeather([FromQuery] double lat, double lon)
        {
            try
            {
                var cityWeather = await _weatherService.GetCityWeatherDataAsync(lat, lon);

                if(cityWeather == null)
                {
                    return NotFound("Prognoza za navedeni grad nedostupna.");
                }
                return Ok(cityWeather);
            }
            catch(HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(502, "Problem s vanjskim API-jem.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, $"Greška na serveru");
            } 
                
        }
    }
}
