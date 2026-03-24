using meat_console_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace meat_console_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _service;

        public SessionController (ISessionService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create()
        {
            var result = await _service.CreateSession();

            if(!result.Success)
            {
                return Conflict(result.Error);
            }

            return Created($"/sessions/{result.Data}", result.Data);
        }

        [HttpPatch("close")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CloseSession()
        {
            var result = await _service.CloseSession();

            if(!result.Success) 
                return Conflict(result.Error);

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllSessions()
        {
            var result = await _service.ListAllSessions();

            return Ok(result.Data);
        }

    }
}
