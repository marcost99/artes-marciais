using ArtesMarciais.Core.Entities;

namespace ArtesMarciais.Infra.Repositories.Interfaces
{
    public interface ILutadorRepository
    {
        Task Adicionar(Lutador lutador);
        Task<IEnumerable<Lutador>?> Listar();
        void Atualizar(Lutador lutador);
        Task<Lutador?> ListarPorCpf(string cpf);
        Task SaveChangesAsync();
        void RemoveRange(IEnumerable<LutadorCampeonato> lutadorCampeonato);
    }
}
