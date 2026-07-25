using EcommerceAPI.Models.Entities;
using System.Security.Claims;

namespace EcommerceAPI.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);

    }
}
