using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EcommerceAPI.Models.Entities;
using EcommerceAPI.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace EcommerceAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateToken(User user)
        {
            // clave
            string secretKey = _configuration["JwtSettings:SecretKey"]!;

            //claims
            var claims = new List<Claim>
            {
               new Claim(JwtRegisteredClaimNames.Name, user.Name),
               new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var expiration = TimeSpan.FromHours(3);

            var token = GenerateJwtToken(secretKey, claims, expiration);
            return token;

        }

        //metodo
        public string GenerateJwtToken(string secretKey, IEnumerable<Claim> claims, TimeSpan expiration)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                claims: claims,
                expires: DateTime.UtcNow.Add(expiration),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
