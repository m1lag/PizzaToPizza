using Microsoft.EntityFrameworkCore;
using PizzaToPizza.Data;
using PizzaToPizza.Dtos.Orders;
using PizzaToPizza.Models;

namespace PizzaToPizza.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(int userId)
        {
            var cart = await _context.CartItems
                .Include(x => x.Pizza)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            if (!cart.Any())
                return;

            var total = cart.Sum(x =>
                x.Pizza.Price * x.Quantity);

            var order = new Order
            {
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                Total = total,
                Status = "Pending"
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            foreach (var item in cart)
            {
                _context.OrderItems.Add(new OrderItem
                {
                    OrderId = order.Id,
                    PizzaId = item.PizzaId,
                    Quantity = item.Quantity,
                    Price = item.Pizza.Price
                });
            }

            _context.CartItems.RemoveRange(cart);

            var promo = await _context.PromoCodes
            .FirstOrDefaultAsync(x =>
                x.UserId == userId &&
                !x.IsUsed &&
                x.ExpiryDate > DateTime.UtcNow
            );

            

            await _context.SaveChangesAsync();


        }

        public async Task ApproveAsync(int id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(x => x.Id == id);

            if (order == null) return;

            order.Status = "Approved";

            var promo = await _context.PromoCodes
                .FirstOrDefaultAsync(x =>
                    x.UserId == order.UserId &&
                    !x.IsUsed &&
                    x.ExpiryDate > DateTime.UtcNow
                );

            if (promo != null)
            {
                promo.IsUsed = true;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderDto>> GetMyAsync(int userId)
        {
            return await _context.Orders
                .Where(x => x.UserId == userId)
                .Include(x => x.Items)
                .ThenInclude(x => x.Pizza)
                .OrderByDescending(x => x.Id)
                .Select(x => new OrderDto
                {
                    Id = x.Id,
                    Total = x.Total,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt,
                    Items = x.Items
                        .Select(i =>
                            i.Pizza.Name +
                            " x" +
                            i.Quantity)
                        .ToList()
                })
                .ToListAsync();
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            return await _context.Orders
                .Include(x => x.User)
                .Include(x => x.Items)
                .ThenInclude(x => x.Pizza)
                .OrderByDescending(x => x.Id)
                .Select(x => new OrderDto
                {
                    Id = x.Id,
                    UserName = x.User.FullName,
                    Total = x.Total,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt,
                    Items = x.Items
                        .Select(i =>
                            i.Pizza.Name +
                            " x" +
                            i.Quantity)
                        .ToList()
                })
                .ToListAsync();
        }

        public async Task RejectAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null) return;

            order.Status = "Rejected";

            await _context.SaveChangesAsync();
        }
    }
}