using CapitalPlacement.Application.DTOs;
using CapitalPlacement.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly IApplicationFormService _formService;
        public ApplicationFormController(IApplicationFormService formService)
        {
            _formService = formService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ApplicationFormDTO model)
        {
            await _formService.UpdateAsync(id, model);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _formService.GetAsync(id);
            return Ok(response);
        }
    }
}
