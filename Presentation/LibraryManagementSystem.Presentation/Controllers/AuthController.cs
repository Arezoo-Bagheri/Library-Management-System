using LibraryManagementSystem.Application.Auth;
using LibraryManagementSystem.Presentation.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtToken _jwtToken;

        public AuthController(IJwtToken jwtToken) => _jwtToken = jwtToken;


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin user)
        {
            if (user.Username == "arezoo" && user.Password == "12345")
            {
                var token = await _jwtToken.GenerateToken(user.Username, user.Password);
                return Ok(token);
            }

            return Unauthorized();
        }



    }
}
