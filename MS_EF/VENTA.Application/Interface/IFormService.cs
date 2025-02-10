using MS_EF.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS_EF.Dto;

namespace MS_EF.Application.Interface
{
    public interface IFormService
    {
        Task<RespuestaGenerica<List<FormDto>>> GetAllFormsAsync();
        Task<RespuestaGenerica<FormDto>> GetFormByIdAsync(int id);
        Task<RespuestaGenerica<FormDto>> CreateFormAsync(FormDto formDto);
        Task<RespuestaGenerica<FormDto>> UpdateFormAsync(int id, FormDto formDto);
        Task<RespuestaGenerica<bool>> DeleteFormAsync(int id);
    }
}
