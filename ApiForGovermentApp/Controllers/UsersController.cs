using ApiForGovermentApp.Models;
using ApiForGovermentApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiForGovermentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UserService _userService { get; set; }
        public UsersController(UserService userService) {
            _userService = userService; 
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto) {
            bool result = await _userService.FindUser(userDto.Login, userDto.Password);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            if (await _userService.UserExists(userDto.Login))
            {
                return Conflict("User already exists");
            }
            _userService.AddUser(userDto.Login, userDto.Password);
            return Ok();
        }
    }
}
