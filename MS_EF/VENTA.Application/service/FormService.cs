using Microsoft.EntityFrameworkCore;
using MS_EF.Application.Interface;
using MS_EF.Domain.Entity;
using MS_EF.Domain.Interface;
using MS_EF.Dto;
using MS_EF.Infrastructure.Utilidades;
using MS_EF.Dto;

namespace MS_EF.Application.service
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _repository;

        public FormService(IFormRepository repository)
        {
            _repository = repository;
        }

        public async Task<RespuestaGenerica<List<FormDto>>> GetAllFormsAsync()
        {
            try
            {
                var forms = await _repository.GetFormsAsync();
                var formDtos = forms.Select(f => f.Mapear<FormDto>()).ToList();

                return RespuestaGenerica<List<FormDto>>.RespuestaExito(formDtos);
            }
            catch (Exception ex)
            {
                return RespuestaGenerica<List<FormDto>>.RespuestaError($"Error al obtener formularios: {ex.Message}");
            }
        }

        public async Task<RespuestaGenerica<FormDto>> GetFormByIdAsync(int id)
        {
            try
            {
                var form = await _repository.GetFormByIdAsync(id);

                if (form == null)
                    return RespuestaGenerica<FormDto>.RespuestaError("Formulario no encontrado");

                return RespuestaGenerica<FormDto>.RespuestaExito(form.Mapear<FormDto>());
            }
            catch (Exception ex)
            {
                return RespuestaGenerica<FormDto>.RespuestaError($"Error al obtener el formulario: {ex.Message}");
            }
        }

        public async Task<RespuestaGenerica<FormDto>> CreateFormAsync(FormDto formDto)
        {
            try
            {
                var form = formDto.Mapear<Form>();
                await _repository.CreateFormAsync(form);

                return RespuestaGenerica<FormDto>.RespuestaExito(form.Mapear<FormDto>(), "Formulario creado exitosamente");
            }
            catch (Exception ex)
            {
                return RespuestaGenerica<FormDto>.RespuestaError($"Error al crear el formulario: {ex.Message}");
            }
        }

        public async Task<RespuestaGenerica<FormDto>> UpdateFormAsync(int id, FormDto formDto)
        {
            try
            {
                var form = await _repository.GetFormByIdAsync(id);
                if (form == null)
                    return RespuestaGenerica<FormDto>.RespuestaError("Formulario no encontrado");

                form = formDto.Mapear<Form>();
                await _repository.UpdateFormAsync(form);

                return RespuestaGenerica<FormDto>.RespuestaExito(form.Mapear<FormDto>(), "Formulario actualizado exitosamente");
            }
            catch (Exception ex)
            {
                return RespuestaGenerica<FormDto>.RespuestaError($"Error al actualizar el formulario: {ex.Message}");
            }
        }

        public async Task<RespuestaGenerica<bool>> DeleteFormAsync(int id)
        {
            try
            {
                var eliminado = await _repository.DeleteFormAsync(id);
                if (!eliminado)
                    return RespuestaGenerica<bool>.RespuestaError("Formulario no encontrado");

                return RespuestaGenerica<bool>.RespuestaExito(true, "Formulario eliminado correctamente");
            }
            catch (Exception ex)
            {
                return RespuestaGenerica<bool>.RespuestaError($"Error al eliminar el formulario: {ex.Message}");
            }
        }
    }
}
