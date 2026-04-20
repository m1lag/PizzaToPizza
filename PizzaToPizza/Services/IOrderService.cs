using PizzaToPizza.Dtos.Orders;

namespace PizzaToPizza.Services
{
    public interface IOrderService
    {
        Task CreateAsync(int userId);

        Task<List<OrderDto>> GetMyAsync(int userId);

        Task<List<OrderDto>> GetAllAsync();

        Task ApproveAsync(int id);

        Task RejectAsync(int id);
    }
}