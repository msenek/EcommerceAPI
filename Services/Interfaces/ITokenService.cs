using EcommerceAPI.Models.Entities;
using System.Security.Claims;

namespace EcommerceAPI.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
        string GenerateJwtToken(string secretKey, IEnumerable<Claim> claims, TimeSpan expiration);
    }
}
