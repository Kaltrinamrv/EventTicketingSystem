/*using Microsoft.IdentityModel.Tokens;
using backend.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Data;

namespace backend.Helpers
{
    public class TokenGenerator
    {
        private readonly IConfiguration _configuration;
        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(User user)
        {
            //var role = user.Role == Role.User ? "user" : "admin";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("sub", user.UserID.ToString()), 
                new Claim("username", user.Username),
                //new Claim("role", role),
                new Claim("issuer", _configuration["Jwt:Issuer"]),
                new Claim("audience", _configuration["Jwt:Audience"]),
                new Claim("expiration", DateTime.UtcNow.AddHours(6).ToString())

            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Token expiration time
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
*/