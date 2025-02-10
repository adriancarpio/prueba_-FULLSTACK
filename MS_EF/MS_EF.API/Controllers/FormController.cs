using Microsoft.AspNetCore.Mvc;
using MS_EF.Application.Interface;
using MS_EF.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using MS_EF.Dto;

namespace MS_EF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpGet]
        public async Task<ActionResult<RespuestaGenerica<List<FormDto>>>> GetAllForms()
        {
            var response = await _formService.GetAllFormsAsync();
            if (response.EsValida)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RespuestaGenerica<FormDto>>> GetFormById(int id)
        {
            var response = await _formService.GetFormByIdAsync(id);
            if (response.EsValida)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpPost]
        public async Task<ActionResult<RespuestaGenerica<FormDto>>> CreateForm([FromBody] FormDto formDto)
        {
            var response = await _formService.CreateFormAsync(formDto);
            if (response.EsValida)
            {
                return CreatedAtAction(nameof(GetFormById), new { id = response.Resultado?.Id }, response); // 201 Created
            }
            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RespuestaGenerica<FormDto>>> UpdateForm(int id, [FromBody] FormDto formDto)
        {
            var response = await _formService.UpdateFormAsync(id, formDto);
            if (response.EsValida)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RespuestaGenerica<bool>>> DeleteForm(int id)
        {
            var response = await _formService.DeleteFormAsync(id);
            if (response.EsValida)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
