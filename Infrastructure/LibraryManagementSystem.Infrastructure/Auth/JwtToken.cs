using LibraryManagementSystem.Application.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryManagementSystem.Infrastructure.Auth
{
    public class JwtToken : IJwtToken
    {
        private readonly IConfiguration _configuration;

        public JwtToken(IConfiguration configuration) =>

            _configuration = configuration;


        public async Task<string> GenerateToken(string userId, string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Name, username),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
            );

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
