using UserService.Application.DTO;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenServices _tokenService;
        private readonly IUserRepository _userRepository;

        public AuthService(ITokenServices tokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }
            var token = _tokenService.GenerateToken(user);

            return new AuthResponse(token);
        }
        

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            if (await _userRepository.GetByEmailAsync(request.Email)!=null)
            {
                throw new ApplicationException("Email is already registered.");
            }
            var user = new User
            {
                Id =Guid.NewGuid(),
                Email = request.Email,
                Name = request.name,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            };

            var userId = await _userRepository.CreateAsync(user);

            var token = _tokenService.GenerateToken(user);

            return new AuthResponse(token);
        
    }
    }
}
