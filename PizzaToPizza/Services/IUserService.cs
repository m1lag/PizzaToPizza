using PizzaToPizza.Dtos;

namespace PizzaToPizza.Services
{
    public interface IUserService
    {
        Task<UserDto> RegisterAsync(RegisterDto dto);
        Task<LoginResponseDto?> LoginAsync(LoginDto dto);
        Task<UserDto?> GetByIdAsync(int id);

        Task<List<UserDto>> GetAllAsync();
    }
}