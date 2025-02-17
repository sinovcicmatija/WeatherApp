using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Interfaces;
using WeatherAPI.Models;
using WeatherAPI.Services;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;

        }

        [HttpGet]
        [Route("cityData")]
        public async Task<IActionResult> GetCity([FromQuery] string name)
        {
            try
            {
                var cityData = await _cityService.GetCityCoordinatesAsync(name);

                if (cityData == null) {
                    return NotFound("Grad nije pronađen");
                }
                return Ok(cityData);
            } 
            catch (HttpRequestException ex)

            {
                Console.WriteLine(ex.Message);
                return StatusCode(502, "Problem s vanjskim API-jem.");
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, $"Greška na serveru");
            } //test commit
        }
    }
}
