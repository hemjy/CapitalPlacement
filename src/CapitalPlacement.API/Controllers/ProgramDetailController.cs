using CapitalPlacement.Application.DTOs;
using CapitalPlacement.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement.API.Controllers
{
    [Route("api/program")]
    [ApiController]
    public class ProgramDetailController : ControllerBase
    {
        private readonly IProgramProcessingService _service;
        public ProgramDetailController(IProgramProcessingService service)
        {
            _service = service;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProgramDetailDTO model)
        {
            await _service.UpdateProgramDetailAsync(id, model);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _service.GetProgramDetailsAsync(id);
            return Ok(response);
        }

        [HttpPost("{employerId}")]
        public async Task<IActionResult> Create([FromBody] ProgramDetailDTO model, Guid employerId)
        {
            var id = Guid.NewGuid();
              await _service.CreateProgramDetailAsync(id, model, employerId);
            return Created($"/api/program/{id}", new { id });
        }
    }
}
