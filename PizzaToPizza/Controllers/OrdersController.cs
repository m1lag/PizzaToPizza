using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaToPizza.Services;

namespace PizzaToPizza.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        private int GetUserId()
        {
            return int.Parse(
                User.FindFirst("sub")!.Value
            );
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create()
        {
            await _service.CreateAsync(GetUserId());
            return Ok();
        }

        [HttpGet("my")]
        public async Task<IActionResult> My()
        {
            return Ok(
                await _service.GetMyAsync(GetUserId())
            );
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPut("{id}/approve")]
        public async Task<IActionResult> Approve(int id)
        {
            await _service.ApproveAsync(id);
            return Ok();
        }

        [HttpPut("{id}/reject")]
        public async Task<IActionResult> Reject(int id)
        {
            await _service.RejectAsync(id);
            return Ok();
        }
    }
}