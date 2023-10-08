using CapitalPlacement.Application.DTOs;
using CapitalPlacement.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement.API.Controllers
{
    [Route("api/program/preview")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramProcessingService _service;
        public ProgramController(IProgramProcessingService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _service.Preview(id);
            return Ok(response);
        }
    }
}
