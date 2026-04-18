using Microsoft.EntityFrameworkCore;
using PizzaToPizza.Data;
using PizzaToPizza.Dtos;

namespace PizzaToPizza.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IJwtService _jwtService;

        public UserService(AppDbContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<UserDto> RegisterAsync(RegisterDto dto)
        {
            var exists = await _context.Users
                .AnyAsync(x => x.Email == dto.Email);

            if (exists)
                throw new Exception("Email already exists");

            var user = new User
            {
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                FullName = dto.FullName,
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName
            };
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == dto.Email);

            if (user == null)
                return null;

            bool valid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);

            if (!valid)
                return null;

            var token = _jwtService.GenerateToken(user);

            return new LoginResponseDto
            {
                Token = token
            };
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Where(x => x.Id == id)
                .Select(x => new UserDto
                {
                    Id = x.Id,
                    Email = x.Email,
                    FullName = x.FullName
                })
                .FirstOrDefaultAsync();
        }
    }
}