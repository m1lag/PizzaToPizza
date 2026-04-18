using Microsoft.EntityFrameworkCore;
using PizzaToPizza.Data;
using PizzaToPizza.Dtos;
using PizzaToPizza.Models;

namespace PizzaToPizza.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly AppDbContext _context;

        public PizzaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PizzaDto>> GetAllAsync()
        {
            return await _context.Pizzas
                .Include(x => x.Category)
                .Select(x => new PizzaDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Category = x.Category.Name
                })
                .ToListAsync();
        }

        public async Task<PizzaDto?> GetByIdAsync(int id)
        {
            return await _context.Pizzas
                .Include(x => x.Category)
                .Where(x => x.Id == id)
                .Select(x => new PizzaDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Category = x.Category.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<PizzaDto> CreateAsync(CreatePizzaDto dto)
        {
            var pizza = new Pizza
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                CategoryId = dto.CategoryId
            };

            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();

            var category = await _context.Categories.FindAsync(dto.CategoryId);

            return new PizzaDto
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Description = pizza.Description,
                Price = pizza.Price,
                Category = category?.Name ?? ""
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdatePizzaDto dto)
        {
            var pizza = await _context.Pizzas.FindAsync(id);

            if (pizza == null)
                return false;

            pizza.Name = dto.Name;
            pizza.Description = dto.Description;
            pizza.Price = dto.Price;
            pizza.CategoryId = dto.CategoryId;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);

            if (pizza == null)
                return false;

            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}