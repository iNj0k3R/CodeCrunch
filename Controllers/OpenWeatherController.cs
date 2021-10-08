using CodeCrunch.Services.OpenWeather;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeCrunch.Controllers
{
    [Route("weather")]
    [ApiController]
    public class OpenWeatherController : ControllerBase
    {
        private readonly IOpenWeatherService _openWeatherService;

        public OpenWeatherController(IOpenWeatherService openWeatherService)
        {
            _openWeatherService = openWeatherService;
        }
        [HttpGet("city/{cityName}")]
        public async Task<IActionResult> GetCityWeatherAsync(string cityName)
        {
            try
            {
                var weatherData = await _openWeatherService.GetCurrentWeatherAsync(cityName);
                var response = new
                {
                    country = weatherData.sys.country,
                    name = weatherData.name,
                    temp = weatherData.main.temp
                };
                return Ok(response);
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    status = 404,
                    message = "weather data not found"
                });
            }
            
        }
        [HttpGet("search")]
        public async Task<IActionResult> GetLocationWeatherAsync(string? latitude = "", string? longitude="", string? pin_code="")
        {
            try
            {
                var weatherData = await _openWeatherService.GetCurrentWeatherByLocationAsync(latitude, longitude, pin_code);
                var response = new
                {
                    country = weatherData.sys.country,
                    name = weatherData.name,
                    temp = weatherData.main.temp,
                    min_temp = weatherData.main.temp_min,
                    max_temp = weatherData.main.temp_max,
                    latitude = weatherData.coord.lat,
                    longitude = weatherData.coord.lon
                };
                return Ok(response);
            }
            catch (Exception)
            {
                return NotFound(new{
                    status = 404,
                    message = "weather data not found"
                });
            }
            
        }
    }
}
