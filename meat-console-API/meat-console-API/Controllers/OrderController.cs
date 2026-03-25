using meat_console_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace meat_console_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateOrder()
        {
            var result = await _service.CreateOrder();

            if (!result.Success)
                return Conflict(result.Error);


            return Created($"orders/{result.Data}", result.Data);
        }

        [HttpPatch("close")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CloseOrder()
        {
            var result = await _service.CloseOrder();

            if (!result.Success)
                return Conflict(result.Error);

            return Ok(result.Data);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListAllOrders()
        {
            var result = await _service.ListAllOrders();

            return Ok(result.Data);
        }

        [HttpGet("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var result = await _service.GetOrderById(orderId);

            if (!result.Success)
                return NotFound(result.Error);

            return Ok(result.Data);
        }
    }
}
