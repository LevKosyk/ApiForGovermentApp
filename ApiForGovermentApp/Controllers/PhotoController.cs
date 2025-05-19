using ApiForGovermentApp.Models;
using ApiForGovermentApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiForGovermentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly PhotoService _photoService;
        private readonly UserService _userService;

        public PhotoController(PhotoService photoService, UserService userService)
        {
            _photoService = photoService;
            _userService = userService;
        }

        [HttpPost("sendPhoto")]
        public async Task<IActionResult> PostPhoto([FromBody] PhotoRequest photoRequest)
        {
            if (photoRequest == null)
            {
                return BadRequest("Photo request is null.");
            }

            if (string.IsNullOrWhiteSpace(photoRequest.Login))
            {
                return BadRequest("Login is required.");
            }

            var user = await _userService.FindUser(photoRequest.Login);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var users = await _userService.GetAllUsers();
            if (users == null || users.Count == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No users found in the system.");
            }

            User randomUser = null;
            var random = new Random();

            int maxAttempts = 10;
            int attempts = 0;

            do
            {
                randomUser = users[random.Next(users.Count)];
                attempts++;
            } while (randomUser != null && randomUser.Id == user.Id && attempts < maxAttempts);

            if (randomUser == null || randomUser.Id == user.Id)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not find a different random user.");
            }

            var result = await _photoService.AddPhoto(
                photoRequest.Longitude,
                photoRequest.Latitude,
                photoRequest.Url,
                photoRequest.Date,
                user,
                photoRequest.Description,
                photoRequest.Situation,
                randomUser
            );

            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to upload the photo.");
            }

            return Ok("Photo uploaded successfully.");
        }

        [HttpGet("getDaysWithMarkers")]
        public async Task<IActionResult> GetDaysWithMarkersByMonth([FromQuery] int month, [FromQuery] int year, [FromQuery] string login)
        {
            if (month < 1 || month > 12)
                return BadRequest("Month must be between 1 and 12.");

            if (year < 1900)
                return BadRequest("Year must be a valid year.");

            if (string.IsNullOrWhiteSpace(login))
                return BadRequest("Login is required.");

            var user = await _userService.FindUser(login);
            if (user == null)
                return NotFound("User not found.");

            var dates = await _photoService.GetDatesWhereIsPhotoByMonth(user.Id, month, year);
            if (dates == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving dates.");

            return Ok(dates);
        }

        [HttpGet("getDataByDay")]
        public async Task<IActionResult> GetDataByDay([FromQuery] string date, [FromQuery] string login)
        {
            if (string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(login))
                return BadRequest("Date and login are required.");

            if (!DateTime.TryParse(date, out var parsedDate))
                return BadRequest("Invalid date format. Use yyyy-MM-dd.");

            var user = await _userService.FindUser(login);
            if (user == null)
                return NotFound("User not found.");

            var photos = await _photoService.GetPhotosByDate(parsedDate, user.Id);
            if (photos == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving photos.");

            return Ok(photos);
        }

        [HttpGet("getDataByDayForCrime")]
        public async Task<IActionResult> GetDataByDayForCrime([FromQuery] string date, [FromQuery] string login)
        {
            if (string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(login))
                return BadRequest("Date and login are required.");

            if (!DateTime.TryParse(date, out var parsedDate))
                return BadRequest("Invalid date format. Use yyyy-MM-dd.");

            var user = await _userService.FindUser(login);
            if (user == null)
                return NotFound("User not found.");

            var photos = await _photoService.GetPhotosByDateForCrime(parsedDate, user.Id);
            if (photos == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving photos.");

            return Ok(photos);
        }
    }
}
