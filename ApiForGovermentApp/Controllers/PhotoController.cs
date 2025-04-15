using ApiForGovermentApp.Models;
using ApiForGovermentApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiForGovermentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        public PhotoService _photoService { get; set; }
         public UserService _userService { get; set; }
        public PhotoController(PhotoService photoService, UserService userService)
        {
            _photoService = photoService;
            _userService = userService;
        }
        [HttpPost("sendPhoto")]
        public async Task<IActionResult> PostPhoto([FromBody] PhotoRequest photoRequest)
        {
            Console.WriteLine(photoRequest.Latitude);
            User user = await _userService.FindUser(photoRequest.Login);
            if (user == null)
            {
                return NotFound("User not found");
            }

            _photoService.AddPhoto(photoRequest.Longitude, photoRequest.Latitude, photoRequest.Url, photoRequest.Date, user, photoRequest.Description, photoRequest.Situation);
            return Ok("Photo uploaded successfully");
        }
        [HttpGet("getDaysWithMarkers")]
        public async Task<IActionResult> GetDaysWithMarkersByMonth([FromQuery] int month, [FromQuery] int year, [FromQuery] string login)
        {
            if (month < 1 || month > 12)
            {
                return BadRequest("Month must be between 1 and 12.");
            }

            if (year < 1900)
            {
                return BadRequest("Year must be a valid year.");
            }

            if (string.IsNullOrWhiteSpace(login))
            {
                return BadRequest("Login is required.");
            }

            User user = await _userService.FindUser(login);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            var dates = await _photoService.GetDatesWhereIsPhotoByMonth(user.Id, month, year);
            if (dates == null || dates.Count == 0)
            {
                return Ok(new List<DateTime>());  
            }

            return Ok(dates);
        }


        [HttpGet("getDataByDay")]
        public async Task<IActionResult> GetDataByDay([FromQuery] string date, [FromQuery] string login)
        {
            if (!DateTime.TryParse(date, out var parsedDate))
            {
                return BadRequest("Invalid date format. Use yyyy-MM-dd");
            }

            User user = await _userService.FindUser(login);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var photos = await _photoService.GetPhotosByDate(parsedDate, user.Id);
            return Ok(photos);
        }
    }
}
