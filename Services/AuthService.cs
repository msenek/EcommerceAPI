using EcommerceAPI.Models.DTOs;
using EcommerceAPI.Models.Entities;
using EcommerceAPI.Middleware;
using EcommerceAPI.Services.Interfaces;
using EcommerceAPI.Repositories.Interfaces;

namespace EcommerceAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;
        public AuthService(IAuthRepository authRepo, ITokenService tokenService)
        {
            _authRepository = authRepo;
            _tokenService = tokenService;
        }

        public async Task RegisterAsync(RegisterRequestDTO RegisterRequestDto)
        {
            var userEmail = await _authRepository.GetUserByEmailAsync(RegisterRequestDto.Email);

            if (userEmail != null)
                throw new ConflictException("Email already exists");

            var user = new User
            {
                Name = RegisterRequestDto.Name,
                Email = RegisterRequestDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(RegisterRequestDto.Password)
            };
            await _authRepository.AddAsync(user);
        }


        public async Task<string> LoginAsync(LoginRequestDTO LoginRequestDto)
        {
            var user = await _authRepository.GetUserByEmailAsync(LoginRequestDto.Email);

            if (user == null)
                throw new UnauthorizedException("Invalid credentials");

            bool isValid = BCrypt.Net.BCrypt.Verify(LoginRequestDto.Password, user.Password);

            if (!isValid)
                throw new UnauthorizedException("Invalid credentials");

            var token = _tokenService.CreateToken(user);
            return token;

        }
    }
}
