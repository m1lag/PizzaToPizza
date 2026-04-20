using Microsoft.EntityFrameworkCore;
using PizzaToPizza.Data;
using PizzaToPizza.Dtos;
using PizzaToPizza.Models;

namespace PizzaToPizza.Services
{
    public class PromoCodeService : IPromoCodeService
    {
        private readonly AppDbContext _context;

        public PromoCodeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PromoCodeDto>> GetAllAsync()
        {
            return await _context.PromoCodes
                .Select(x => new PromoCodeDto
                {
                    Id = x.Id,
                    Code = x.Code,
                    DiscountPercent = x.DiscountPercent,
                    ExpiryDate = x.ExpiryDate,
                    IsExpired = x.ExpiryDate < DateTime.UtcNow
                })
                .ToListAsync();
        }

        public async Task<PromoCodeDto?> GetByIdAsync(int id)
        {
            return await _context.PromoCodes
                .Where(x => x.Id == id)
                .Select(x => new PromoCodeDto
                {
                    Id = x.Id,
                    Code = x.Code,
                    DiscountPercent = x.DiscountPercent,
                    ExpiryDate = x.ExpiryDate,
                    IsExpired = x.ExpiryDate < DateTime.UtcNow
                })
                .FirstOrDefaultAsync();
        }

        public async Task<PromoCodeDto> CreateAsync(CreatePromoCodeDto dto)
        {
            var promo = new PromoCode
            {
                Code = dto.Code,
                DiscountPercent = dto.DiscountPercent,
                ExpiryDate = dto.ExpiryDate.HasValue
                    ? DateTime.SpecifyKind(
                        dto.ExpiryDate.Value,
                        DateTimeKind.Utc
                      )
                    : DateTime.UtcNow.AddDays(14)
            };

            _context.PromoCodes.Add(promo);
            await _context.SaveChangesAsync();

            return new PromoCodeDto
            {
                Id = promo.Id,
                Code = promo.Code,
                DiscountPercent = promo.DiscountPercent,
                ExpiryDate = promo.ExpiryDate,
                IsExpired = promo.ExpiryDate < DateTime.UtcNow
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdatePromoCodeDto dto)
        {
            var promo = await _context.PromoCodes.FindAsync(id);

            if (promo == null)
                return false;

            promo.Code = dto.Code;
            promo.DiscountPercent = dto.DiscountPercent;
            promo.ExpiryDate = dto.ExpiryDate;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var promo = await _context.PromoCodes.FindAsync(id);

            if (promo == null)
                return false;

            _context.PromoCodes.Remove(promo);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<PromoCodeDto>> GetMyAsync(int userId)
        {
            return await _context.PromoCodes
                .Where(x =>
                    x.UserId == userId &&
                    !x.IsUsed &&
                    x.ExpiryDate > DateTime.UtcNow
)
                .Select(x => new PromoCodeDto
                {
                    Id = x.Id,
                    Code = x.Code,
                    DiscountPercent = x.DiscountPercent,
                    PizzaName =
                        x.Pizza != null
                            ? x.Pizza.Name
                            : "Універсальний",
                    IsUsed = x.IsUsed,
                    ExpiryDate = x.ExpiryDate
                })
                .ToListAsync();
        }

        public async Task<bool> ActivateAsync(
        int id,
        int userId)
        {
            var promo =
                await _context.PromoCodes
                .FirstOrDefaultAsync(x =>
                    x.Id == id &&
                    x.UserId == userId &&
                    !x.IsUsed
                );

            if (promo == null)
                return false;

            promo.IsUsed = true;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}