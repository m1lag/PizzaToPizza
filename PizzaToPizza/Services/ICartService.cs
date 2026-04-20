using PizzaToPizza.Dtos;

namespace PizzaToPizza.Services
{
    public interface ICartService
    {
        Task<object> GetAsync(int userId);

        Task AddAsync(int userId, AddToCartDto dto);

        Task DeleteAsync(int userId, int itemId);

        Task ClearAsync(int userId);
    }
}