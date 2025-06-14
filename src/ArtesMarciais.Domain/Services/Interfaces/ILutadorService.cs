using ArtesMarciais.Core.DTO.Listar;
using ArtesMarciais.Core.DTO.Registrar;

namespace ArtesMarciais.Domain.Services.Interfaces
{
    public interface ILutadorService
    {
        Task<LutadorListarDTO> Registrar(LutadorRegistrarDTO request);
        Task<IEnumerable<LutadorListarDTO>?> Listar();
    }
}
