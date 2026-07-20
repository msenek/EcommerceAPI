using EcommerceAPI.Models.DTOs;

namespace EcommerceAPI.Services.Interfaces
{
    public interface IAuthService
    {

        Task RegisterAsync(RegisterRequestDTO registerRequestDto);
        Task<string> LoginAsync(LoginRequestDTO LoginRequestDto);
    }
}
