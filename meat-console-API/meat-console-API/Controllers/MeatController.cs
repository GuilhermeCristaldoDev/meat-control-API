using meat_console_API.DTOs;
using meat_console_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace meat_console_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MeatController : ControllerBase
    {
        private readonly IMeatService _service;

        public MeatController (IMeatService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateMeat(CreateMeatRequestDto meatDto)
        {
            var result = await _service.CreateMeat(meatDto);

            if (!result.Success)
                return Conflict(result.Error);

            return Created($"meats/{result.Data}", result.Data);
        }
    }
}
