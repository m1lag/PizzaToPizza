using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaToPizza.Data;
using PizzaToPizza.Models;

namespace PizzaToPizza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PizzasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pizzas = await _context.Pizzas.Include(p => p.Category).ToListAsync();
            return Ok(pizzas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pizza = await _context.Pizzas.Include(p => p.Category)
                                             .FirstOrDefaultAsync(p => p.Id == id);
            if (pizza == null) return NotFound();
            return Ok(pizza);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = pizza.Id }, pizza);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Pizza pizza)
        {
            if (id != pizza.Id) return BadRequest();

            _context.Entry(pizza).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null) return NotFound();

            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
