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

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDTO RegisterRequestDto)
        {
            var userEmail = await _authRepository.GetUserByEmailAsync(RegisterRequestDto.Email);
            if (userEmail != null)
            {
                throw new ConflictException("A user with this email already exists.");
            }

            var user = new User
            {
                Name = RegisterRequestDto.Name.Trim(),
                Email = RegisterRequestDto.Email.Trim().ToLower(),
                Password = BCrypt.Net.BCrypt.HashPassword(RegisterRequestDto.Password)
            };
            await _authRepository.AddAsync(user);
            var token = _tokenService.CreateToken(user);

            return new AuthResponseDto
            {
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email,
                AccessToken = token
            };
        }


        public async Task<string> LoginAsync(LoginRequestDTO LoginRequestDto)
        {
            var user = await _authRepository.GetUserByEmailAsync(LoginRequestDto.Email);

            bool isValid =  user != null && BCrypt.Net.BCrypt.Verify(LoginRequestDto.Password, user.Password);
            if (!isValid)
                throw new BadRequestException("Invalid email or password");

            var token = _tokenService.CreateToken(user);
            return token;

        }
    }
}
