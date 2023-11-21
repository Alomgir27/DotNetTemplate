using Microsoft.AspNetCore.Mvc;
using SuperHeroApiDotNet7.Services.UserService;
using SuperHeroApiDotNet7.Models;

namespace SuperHeroApiDotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await _userService.GetUsers();
        }
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            var result = await _userService.AddUser(user);
            return Ok(result);
        }
        [HttpGet("getUserById/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var result = await _userService.GetUserById(id);
            if(result == null)
                return NoContent();
            return Ok(result);
        }
        [HttpGet("getUserByEmail/{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var result = await _userService.GetUserByEmail(email);
            if (result == null)
                return NotFound("Not Found");
            return Ok(result);
        }
        [HttpGet("getUserByName/{name}")]
        public async Task<ActionResult<List<User>>> GetUserByName(string name)
        {
            var result = await _userService.GetUserByName(name);
            if (result == null)
                return new List<User>();
            return result.ToList();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> UpdateUser(int id, User request)
        {
            var result = await _userService.UpdateUser(id, request);
            if (result is null)
                return NotFound("Hero not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);
            if (result is null)
                return NotFound("Hero not found.");
            return Ok(result);
        }
    }
}
