using ApiForGovermentApp.Models;
using ApiForGovermentApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiForGovermentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDtoForLogin userDto)
        {
            if (userDto == null || string.IsNullOrWhiteSpace(userDto.Login) || string.IsNullOrWhiteSpace(userDto.Password))
            {
                return BadRequest("Login and password are required.");
            }

            bool result = await _userService.FindUser(userDto.Login, userDto.Password);
            if (result)
            {
                return Ok("Login successful.");
            }
            else
            {
                return NotFound("Invalid login or password.");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            if (userDto == null ||
                string.IsNullOrWhiteSpace(userDto.Login) ||
                string.IsNullOrWhiteSpace(userDto.Password) ||
                string.IsNullOrWhiteSpace(userDto.Name) ||
                string.IsNullOrWhiteSpace(userDto.SecondName))
            {
                return BadRequest("All fields are required.");
            }

            if (await _userService.UserExists(userDto.Login))
            {
                return Conflict("User already exists.");
            }

            bool created = await _userService.AddUser(userDto.Login, userDto.Password, userDto.Name, userDto.SecondName);
            if (!created)
            {
                return StatusCode(500, "Failed to create user due to a server error.");
            }

            return Ok("User registered successfully.");
        }
    }
}
