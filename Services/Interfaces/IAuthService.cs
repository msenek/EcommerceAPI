using System.Threading.Tasks;
using EcommerceAPI.Models.DTOs;

namespace EcommerceAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterRequestDTO registerRequestDto);
        Task<string> LoginAsync(LoginRequestDTO LoginRequestDto);
    }
}
