using Microsoft.EntityFrameworkCore;
using MS_EF.Application.Interface;
using MS_EF.Domain.Entity;
using MS_EF.Domain.Interface;
using MS_EF.Dto;
using MS_EF.Infrastructure.Utilidades;
using MS_EF.Dto;

namespace MS_EF.Application.service
{
    public class InputService : IInputService
    {
        private readonly IInputRepository _repository;

        public InputService(IInputRepository repository)
        {
            _repository = repository;
        }

        public async Task<RespuestaGenerica<List<InputDto>>> GetAllInputsAsync()
        {
            try
            {
                var inputs = await _repository.GetAllAsync();
                var inputDtos = inputs.Select(i => i.Mapear<InputDto>()).ToList();
                return RespuestaGenerica<List<InputDto>>.RespuestaExito(inputDtos);
            }
            catch (Exception ex)
            {
                return RespuestaGenerica<List<InputDto>>.RespuestaError($"Error al obtener inputs: {ex.Message}");
            }
        }

        public async Task<RespuestaGenerica<InputDto>> GetInputByIdAsync(int id)
        {
            try
            {
                var input = await _repository.GetByIdAsync(id);
                if (input == null) return RespuestaGenerica<InputDto>.RespuestaError("Input no encontrado");
                return RespuestaGenerica<InputDto>.RespuestaExito(input.Mapear<InputDto>());
            }
            catch (Exception ex)
            {
                return RespuestaGenerica<InputDto>.RespuestaError($"Error al obtener el input: {ex.Message}");
            }
        }

        public async Task<RespuestaGenerica<InputDto>> AddInputAsync(InputDto inputDto)
        {
            try
            {
                var input = inputDto.Mapear<Input>();
                await _repository.AddAsync(input);
                return RespuestaGenerica<InputDto>.RespuestaExito(inputDto, "Input creado exitosamente");
            }
            catch (Exception ex)
            {
                return RespuestaGenerica<InputDto>.RespuestaError($"Error al crear el input: {ex.Message}");
            }
        }

        public async Task<RespuestaGenerica<bool>> DeleteInputAsync(int id)
        {
            try
            {
                var eliminado = await _repository.DeleteAsync(id);
                if (!eliminado) return RespuestaGenerica<bool>.RespuestaError("Input no encontrado");
                return RespuestaGenerica<bool>.RespuestaExito(true, "Input eliminado correctamente");
            }
            catch (Exception ex)
            {
                return RespuestaGenerica<bool>.RespuestaError($"Error al eliminar el input: {ex.Message}");
            }
        }
    }
}
