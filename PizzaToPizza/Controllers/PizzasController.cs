using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaToPizza.Dtos;
using PizzaToPizza.Services;
using System.Security.Claims;

namespace PizzaToPizza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzasController : ControllerBase
    {
        private readonly IPizzaService _service;

        public PizzasController(IPizzaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pizza = await _service.GetByIdAsync(id);

            if (pizza == null)
                return NotFound();

            return Ok(pizza);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePizzaDto dto)
        {
            var pizza = await _service.CreateAsync(dto);
            return Ok(pizza);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePizzaDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [Authorize]
        [HttpPost("{id}/rate")]
        public async Task<IActionResult> Rate(int id, RatePizzaDto dto)
        {
            var userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value
            );

            var result = await _service.RateAsync(id, userId, dto.Stars);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}