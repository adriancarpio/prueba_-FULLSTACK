using MS_EF.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS_EF.Dto;

namespace MS_EF.Application.Interface
{
    public interface IInputService
    {
        Task<RespuestaGenerica<List<InputDto>>> GetAllInputsAsync();
        Task<RespuestaGenerica<InputDto>> GetInputByIdAsync(int id);
        Task<RespuestaGenerica<InputDto>> AddInputAsync(InputDto inputDto);
        Task<RespuestaGenerica<bool>> DeleteInputAsync(int id);
    }
}
