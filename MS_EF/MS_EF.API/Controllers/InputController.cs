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
    public class InputController : ControllerBase
    {
        private readonly IInputService _inputService;

        public InputController(IInputService inputService)
        {
            _inputService = inputService;
        }

        [HttpGet]
        public async Task<ActionResult<RespuestaGenerica<List<InputDto>>>> GetAllInput()
        {
            var response = await _inputService.GetAllInputsAsync();
            if (response.EsValida)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RespuestaGenerica<InputDto>>> GetInputById(int id)
        {
            var response = await _inputService.GetInputByIdAsync(id);
            if (response.EsValida)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpPost]
        public async Task<ActionResult<RespuestaGenerica<InputDto>>> CreateInput([FromBody] InputDto inputDto)
        {
            var response = await _inputService.AddInputAsync(inputDto);
            if (response.EsValida)
            {
                return CreatedAtAction(nameof(GetInputById), new { id = response.Resultado?.Id }, response);
            }
            return BadRequest(response);
        }

        /*[HttpPut("{id}")]
        public async Task<ActionResult<RespuestaGenerica<InputDto>>> UpdateForm(int id, [FromBody] InputDto InputDto)
        {
            var response = await _inputService.(id, InputDto);
            if (response.EsValida)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }*/

        [HttpDelete("{id}")]
        public async Task<ActionResult<RespuestaGenerica<bool>>> DeleteInput(int id)
        {
            var response = await _inputService.DeleteInputAsync(id);
            if (response.EsValida)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
