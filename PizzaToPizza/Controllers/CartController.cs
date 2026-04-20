using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaToPizza.Dtos;
using PizzaToPizza.Services;
using System.Security.Claims;

namespace PizzaToPizza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        private int GetUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)
                           ?? User.FindFirst("sub");

            if (userIdClaim == null)
                throw new UnauthorizedAccessException("Claim с ID пользователя не найден");

            return int.Parse(userIdClaim.Value);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(
                await _service.GetAsync(GetUserId())
            );
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(
    [FromBody] AddToCartDto dto
)
        {
            await _service.AddAsync(GetUserId(), dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(GetUserId(), id);
            return Ok();
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> Clear()
        {
            await _service.ClearAsync(GetUserId());
            return Ok();
        }
    }
}