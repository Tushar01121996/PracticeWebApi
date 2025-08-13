using Application.Interface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PracticeWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserAuthController : ControllerBase
    {
        private readonly IUserLogin iuserLogin;
        private readonly JwtSettings _jwtSettings;
        public UserAuthController(IUserLogin _iuserLogin, IOptions<JwtSettings> jwtSettings)
        {
            iuserLogin = _iuserLogin;
            _jwtSettings = jwtSettings.Value;
        }
        [HttpPost]
        public async Task<IActionResult> GetByUserName(UserLogin userLogin)
        {
            var result = await iuserLogin.GetbyUserIdAsync(userLogin);
            if(result != null)
            {
                string token = GenerateJwtToken(userLogin.UserName);
                return Ok(new { token = token});
            }
            else
            {
                return NotFound();
            }
        }
        private string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin") // Optional role
            }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
