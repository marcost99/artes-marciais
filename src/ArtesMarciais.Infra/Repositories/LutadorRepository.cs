using ArtesMarciais.Core.Entities;
using ArtesMarciais.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtesMarciais.Infra.Repositories
{
    public class LutadorRepository : ILutadorRepository
    {
        private readonly ArtesMarciaisDbContext _dbContext;

        public LutadorRepository(ArtesMarciaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Adicionar(Lutador lutador)
        {
            await _dbContext.Lutador.AddAsync(lutador);
        }

        public void Atualizar(Lutador lutador)
        {
            _dbContext.Lutador.Update(lutador);
        }

        public void RemoveRange(IEnumerable<LutadorCampeonato> lutadorCampeonato)
        {
            _dbContext.LutadorCampeonato.RemoveRange(lutadorCampeonato);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Lutador?> ListarPorCpf(string cpf)
        {
            var entidade = await _dbContext.Lutador
                                    .AsNoTracking()
                                    .Include(lu => lu.PreparacaoLutaInicial)
                                    .Include(lu => lu.PreparacaoLutaFinal)
                                    .Include(lu => lu.LutadorCampeonato)
                                        .ThenInclude(lc => lc.Campeonato)
                                    .FirstOrDefaultAsync(lu => lu.Cpf == cpf);

            return entidade;
        }

        public async Task<IEnumerable<Lutador>?> Listar()
        {
            var entidades = await _dbContext.Lutador
                                    .AsNoTracking()
                                    .Include(lu => lu.PreparacaoLutaInicial)
                                    .Include(lu => lu.PreparacaoLutaFinal)
                                    .ToListAsync();

            return entidades;
        }
    }
}
