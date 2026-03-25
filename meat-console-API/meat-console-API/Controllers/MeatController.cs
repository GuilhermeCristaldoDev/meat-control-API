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

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMeat([FromQuery] int meatId)
        {
            var result = await _service.DeleteMeat(meatId);

            if(!result.Success)
                return NotFound(result.Error);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListAllMeats()
        {
            var result = await _service.ListAllMeats();

            return Ok(result.Data);
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMeatById(int meatId)
        {
            var result = await _service.GetMeatById(meatId);

            if (!result.Success)
                return NotFound(result.Error);

            return Ok(result.Data);
        }
    }
}
