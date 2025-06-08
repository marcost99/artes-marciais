using ArtesMarciais.Core.DTO;

namespace ArtesMarciais.Domain.Services.Interfaces
{
    public interface ILutadorService
    {
        Task<LutadorDTO> Registrar(LutadorRegistrarDTO request);
        Task<IEnumerable<LutadorDTO>?> Listar();
    }
}
