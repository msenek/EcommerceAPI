using Microsoft.AspNetCore.Mvc;
using EcommerceAPI.Models.DTOs;
using EcommerceAPI.Services.Interfaces;

namespace EcommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequestDTO registerRequestDto)
        {
          
            await _authService.RegisterAsync(registerRequestDto);

            return StatusCode(StatusCodes.Status201Created, new
            {
                Success = true,
                Message = "Register done successfully."
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDTO loginRequestDto)
        {
            var token = await _authService.LoginAsync(loginRequestDto);

            return Ok(new { token });
        }
    }
}