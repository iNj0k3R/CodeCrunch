using CodeCrunch.Services.NASA;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CodeCrunch.Controllers
{
    [Route("nasa")]
    [ApiController]
    public class NASAController : ControllerBase
    {
        private readonly INASAService _NASAService;

        public NASAController(INASAService NASAService)
        {
            _NASAService = NASAService;
        }
        [HttpGet("image-of-month")]
        public async Task<IActionResult> ImageOfMonthAsync()
        {
            try
            {
                DateTime date = DateTime.Now;
                var image = await _NASAService.GetAPOD(date.ToString("yyyy-MM-01"));
                var response = new
                {
                    date = image.date,
                    media_type = image.media_type,
                    title = image.title,
                    url = image.url
                };
                return Ok(response);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode((int)ex.StatusCode,
                    new
                    {
                        status = (int)ex.StatusCode,
                        message = "image/video not found"
                    });
            }                    
        }
        [HttpGet("images-of-month/{year}/{month}")]
        public async Task<IActionResult> ImagesOfMonthAsync(string year, string month)
        {
            try
            {
                var APOD = await _NASAService.GetAPODOfMonth(year, month);
                var response = APOD.Select(t => t.url);
                return Ok(response);
            }
            catch (FormatException ex)
            {
                return BadRequest();
            }
            catch (HttpRequestException ex)
            {
                return StatusCode((int)ex.StatusCode,
                    new
                    {
                        status = (int)ex.StatusCode,
                        message = "image/video not found"
                    });
            }
           
        }
        [HttpGet("videos-of-month/{year}/{month}")]
        public async Task<IActionResult> VideosOfMonthAsync(string year, string month)
        {
            try
            {
                var APOD = await _NASAService.GetAPODOfMonth(year, month);
                var response = APOD.Where(t => t.media_type is "video").Select(t => t.url);
                return Ok(response);
            }
            catch (FormatException ex)
            {
                return BadRequest();

            }
            catch (HttpRequestException ex)
            {
                return StatusCode((int)ex.StatusCode, new
                {
                    status = (int)ex.StatusCode,
                    message = "image/video not found"
                });
            }
        }
        [HttpGet("earth-poly-image/{date}")]
        public async Task<IActionResult> EPICAsync(string date)
        {
            try
            {
                var EPIC = await _NASAService.GetEPIC(date);
                if(EPIC.Length <= 0)
                {
                    return NotFound(new
                    {
                        status = 404,
                        message = "image/video not found"
                    });
                }
                var latLonFiltered = EPIC.Where(t => t.centroid_coordinates.lat >= 10 && t.centroid_coordinates.lat <= 40
                     && t.centroid_coordinates.lon >= 120 && t.centroid_coordinates.lon <= 160);
                var response = latLonFiltered.Select(t => new
                {
                    identifier = t.identifier,
                    caption = t.caption,
                    image = t.image,
                    date = t.date,
                    latitude = t.centroid_coordinates.lat,
                    longitude = t.centroid_coordinates.lon,
                });
                return Ok(response);
            }

            catch (HttpRequestException ex)
            {
                return StatusCode((int)ex.StatusCode, new
                {
                    status = (int)ex.StatusCode,
                    message = "image/video not found"
                });
            }
        }
    }
}
