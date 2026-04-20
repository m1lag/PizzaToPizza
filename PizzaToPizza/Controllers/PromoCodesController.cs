using Microsoft.AspNetCore.Mvc;
using PizzaToPizza.Dtos;
using PizzaToPizza.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace PizzaToPizza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromoCodesController : ControllerBase
    {
        private readonly IPromoCodeService _service;

        public PromoCodesController(IPromoCodeService service)
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
            var promo = await _service.GetByIdAsync(id);

            if (promo == null)
                return NotFound();

            return Ok(promo);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePromoCodeDto dto)
        {
            var promo = await _service.CreateAsync(dto);
            return Ok(promo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePromoCodeDto dto)
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
        [HttpGet("my")]
        public async Task<IActionResult> My()
        {
            var claim = User.Claims.FirstOrDefault(x =>
                x.Type == ClaimTypes.NameIdentifier ||
                x.Type == "nameid" ||
                x.Type == "sub");

            if (claim == null)
                return Unauthorized();

            var userId = int.Parse(User.FindFirst("sub")!.Value);

            var promos = await _service.GetMyAsync(userId);

            return Ok(User.Claims.Select(x => new { x.Type, x.Value }));
        }
    }
}