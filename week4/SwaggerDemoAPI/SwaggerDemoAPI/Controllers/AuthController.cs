using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SwaggerDemoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous] // Allows token generation without auth
    public class AuthController : ControllerBase
    {
        [HttpGet("token")]
        public IActionResult GetToken()
        {
            // Simulate user id and role
            int userId = 1;
            string userRole = "Admin";

            var token = GenerateJSONWebToken(userId, userRole);
            return Ok(new { Token = token });
        }

        [HttpGet("token/poc")]
        public IActionResult GetPOCToken()
        {
            int userId = 2;
            string userRole = "POC";

            var token = GenerateJSONWebToken(userId, userRole);
            return Ok(new { Token = token });
        }
        private string GenerateJSONWebToken(int userId, string userRole)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecretkeythatmeetsthelength"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, userRole),
                new Claim("UserId", userId.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "mySystem",
                audience: "myUsers",
                claims: claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
