using PizzaToPizza.Dtos;

namespace PizzaToPizza.Services
{
    public interface IPizzaService
    {
        Task<List<PizzaDto>> GetAllAsync();
        Task<PizzaDto?> GetByIdAsync(int id);
        Task<PizzaDto> CreateAsync(CreatePizzaDto dto);
        Task<bool> UpdateAsync(int id, UpdatePizzaDto dto);

        Task<bool> RateAsync(int pizzaId, int userId, int stars);
        Task<bool> DeleteAsync(int id);
    }
}