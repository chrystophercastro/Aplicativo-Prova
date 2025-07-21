using Aplicativo_Prova.Domain.Services;
using Aplicativo_Prova.Dtos;
using Microsoft.AspNetCore.Mvc;
namespace Aplicativo_Prova.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroObraController : ControllerBase
    {
        private readonly IRegistroObraService _service;

        public RegistroObraController(IRegistroObraService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegistroObraRequest request)
        {
            await _service.ProcessarAsync(request);
            return Ok();
        }
    }
}
