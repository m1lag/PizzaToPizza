using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaToPizza.Data;
using PizzaToPizza.Models;

namespace PizzaToPizza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromoCodesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PromoCodesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var promoCodes = await _context.PromoCodes.ToListAsync();
            return Ok(promoCodes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var promoCode = await _context.PromoCodes.FindAsync(id);
            if (promoCode == null) return NotFound();
            return Ok(promoCode);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PromoCode promoCode)
        {
            _context.PromoCodes.Add(promoCode);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = promoCode.Id }, promoCode);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PromoCode promoCode)
        {
            if (id != promoCode.Id) return BadRequest();
            _context.Entry(promoCode).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var promoCode = await _context.PromoCodes.FindAsync(id);
            if (promoCode == null) return NotFound();
            _context.PromoCodes.Remove(promoCode);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
