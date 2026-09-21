using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VeterinaryClinic.Business.Dtos.UserDtos;
using VeterinaryClinic.Business.Services;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;
        private readonly UserManager<User> _userManager;

        public UsersController(IUserService userService, ILogger<UsersController> logger, UserManager<User> userManager)
        {
            _userService = userService;
            _logger = logger;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            await _userService.RegisterAsync(registerDto);
            return Ok("Kullanıcı başarıyla oluşturuldu.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _userService.LoginAsync(loginDto);

            if (result == "")
            {
                _logger.LogWarning("Login failed for email: {Email}", loginDto.Email);
                return BadRequest("Email veya şifre hatalı!");
            }

            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager")]
        [HttpPost("create-role")]
        public async Task<IActionResult> Create(CreateRoleDto dto)
        {
            await _userService.CreateRoleAsync(dto);
            return Ok("Rol başarıyla oluşturuldu.");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager")]
        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole(AddRoleDto addRoleDto)
        {
            await _userService.AddRoleAsync(addRoleDto.UserId, addRoleDto.RoleId);
            return Ok("Rol başarıyla atandı.");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("me")]
        public async Task<IActionResult> GetMyProfile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            return Ok(new
            {
                user.FullName,
                user.Email,
                user.PhoneNumber
            });
        }
    }
}
