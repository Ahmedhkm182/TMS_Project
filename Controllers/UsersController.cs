using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.APP.Interface;
using TMS.Core.DTOs;
using TMS.Core.Entities;

namespace TMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            var dtos = users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.UserName,
                Email = u.Email,
                Role = u.Role.ToString() 
            });

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            var dto = new UserDto
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                Role = user.Role.ToString() 
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterDto dto)
        {
            if (!Enum.TryParse(dto.Role.ToString(), out Role role)) 
            {
                return BadRequest("Invalid role specified.");
            }

            var user = new User
            {
                UserName = dto.Username,
                Email = dto.Email,
                PasswordHash = dto.Password,
                Role = role
            };

            var created = await _userService.CreateUserAsync(user);

            return Ok(new UserDto
            {
                Id = created.Id,
                Username = created.UserName,
                Email = created.Email,
                Role = created.Role.ToString() 
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RegisterDto dto)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            if (!Enum.TryParse(dto.Role.ToString(), out Role role)) 
            {
                return BadRequest("Invalid role specified.");
            }

            user.UserName = dto.Username;
            user.Email = dto.Email;
            user.PasswordHash = dto.Password;
            user.Role = role;

            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
