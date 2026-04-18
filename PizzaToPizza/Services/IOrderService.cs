using PizzaToPizza.Models;
using PizzaToPizza.Dtos;

namespace PizzaToPizza.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(int userId, CreateOrderDto dto);

        Task<List<Order>> GetAllAsync();

        Task<Order?> GetByIdAsync(int id);

        Task<List<Order>> GetByUserIdAsync(int userId);

        Task<bool> DeleteAsync(int id);
    }
}