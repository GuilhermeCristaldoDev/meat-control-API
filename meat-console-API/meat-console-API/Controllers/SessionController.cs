using meat_console_API.Repositories.Interfaces;
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
        public async Task<IActionResult> Create()
        {
            var result = await _service.CreateSession();

            if(!result.Success)
            {
                return Conflict(result.Error);
            }

            return Created($"/sessions/{result.Data}", result.Data);
        }
    }
}
