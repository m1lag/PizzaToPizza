using Microsoft.EntityFrameworkCore;
using PizzaToPizza.Data;
using PizzaToPizza.Dtos;
using PizzaToPizza.Models;

namespace PizzaToPizza.Services
{
    public class CartService : ICartService
    {
        private readonly AppDbContext _context;

        public CartService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetAsync(int userId)
        {
            var items = await _context.CartItems
                .Include(x => x.Pizza)
                .Where(x => x.UserId == userId)
                .Select(x => new
                {
                    x.Id,
                    x.Quantity,
                    PizzaId = x.PizzaId,
                    Name = x.Pizza.Name,
                    Price = x.Pizza.Price,
                    Image = x.Pizza.Image
                })
                .ToListAsync();

            return items;
        }

        public async Task AddAsync(int userId, AddToCartDto dto)
        {
            var item = await _context.CartItems
                .FirstOrDefaultAsync(x =>
                    x.UserId == userId &&
                    x.PizzaId == dto.PizzaId);

            if (item == null)
            {
                _context.CartItems.Add(new CartItem
                {
                    UserId = userId,
                    PizzaId = dto.PizzaId,
                    Quantity = dto.Quantity
                });
            }
            else
            {
                item.Quantity += dto.Quantity;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId, int itemId)
        {
            var item = await _context.CartItems
                .FirstOrDefaultAsync(x =>
                    x.Id == itemId &&
                    x.UserId == userId);

            if (item == null)
                return;

            _context.CartItems.Remove(item);

            await _context.SaveChangesAsync();
        }

        public async Task ClearAsync(int userId)
        {
            var items = await _context.CartItems
                .Where(x => x.UserId == userId)
                .ToListAsync();

            _context.CartItems.RemoveRange(items);

            await _context.SaveChangesAsync();
        }
    }
}