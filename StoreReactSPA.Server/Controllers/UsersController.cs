using Microsoft.AspNetCore.Mvc;
using StoreReactSPA.Server.DTOs.CreatedDTOs;
using StoreReactSPA.Server.Services.Inteface;

namespace StoreReactSPA.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto createUserDto)
        {
            try
            {
                var userDto = await _userService.RegisterUserAsync(createUserDto);
                if (userDto == null) return BadRequest("Invalid request data");
                return CreatedAtAction(nameof(GetUserById), new {id=userDto.Id }, userDto);
            }
            catch (Exception ex) {return BadRequest(ex.Message); }
        }
        [HttpGet("{id}")]
        private object GetUserById(Guid id)
        {
            return Ok($"Get user {id}");
        }
    }
}
