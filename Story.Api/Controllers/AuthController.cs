using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Dtos.UserDTOs;
using Store.Api.Dtos;
using Store.Api.Services.AuthServices;

namespace Store.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: /api/auth/register
        [HttpPost("register")]
        public async Task<ActionResult<UserReadDto>> Register([FromBody] UserRegisterDto dto)
        {
            try
            {
                var user = await _authService.RegisterAsync(dto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: /api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult<LoginResultDto>> Login([FromBody] UserLoginDto dto)
        {
            try
            {
                var result = await _authService.LoginAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}

