using PizzaToPizza.Dtos;

namespace PizzaToPizza.Services
{
    public interface IPromoCodeService
    {
        Task<List<PromoCodeDto>> GetAllAsync();
        Task<PromoCodeDto?> GetByIdAsync(int id);
        Task<PromoCodeDto> CreateAsync(CreatePromoCodeDto dto);
        Task<bool> UpdateAsync(int id, UpdatePromoCodeDto dto);
        Task<bool> DeleteAsync(int id);

        Task<bool> ActivateAsync(int id, int userId);
        Task<List<PromoCodeDto>> GetMyAsync(int userId);
    }
}