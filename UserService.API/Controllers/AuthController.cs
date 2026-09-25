using Microsoft.AspNetCore.Http;
using UserService.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Interfaces;

namespace UserService.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                var response = await _authService.RegisterAsync(request);

               
                return Created(string.Empty, response);
            }
            catch (ApplicationException ex)
            {
                
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var response = await _authService.LoginAsync(request);

               
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
