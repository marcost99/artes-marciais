using ArtesMarciais.Core.Entities;

namespace ArtesMarciais.Infra.Repositories.Interfaces
{
    public interface ILutadorRepository
    {
        Task Registrar(Lutador lutador);
        Task<IEnumerable<Lutador>?> Listar();
        Task Atualizar(Lutador lutador);
        Task<Lutador?> BuscarPorCpf(string cpf);
    }
}
