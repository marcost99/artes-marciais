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

        public async Task Registrar(Lutador lutador)
        {
            await _dbContext.PreparacaoLuta.AddAsync(lutador.PreparacaoLutaInicial);

            await _dbContext.SaveChangesAsync();

            lutador.PreparacaoLutaFinal = lutador.PreparacaoLutaInicial;

            await _dbContext.Lutador.AddAsync(lutador);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(Lutador lutador)
        {
            if (lutador.IdPreparacaoLutaInicial == lutador.IdPreparacaoLutaFinal)
            {
                await _dbContext.PreparacaoLuta.AddAsync(lutador.PreparacaoLutaFinal);

                await _dbContext.SaveChangesAsync();
            }

            _dbContext.Lutador.Update(lutador);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Lutador?> BuscarPorCpf(string cpf)
        {
            var entidade = await _dbContext.Lutador
                                    .AsNoTracking()
                                    .Include(lu => lu.PreparacaoLutaInicial)
                                    .Include(lu => lu.PreparacaoLutaFinal)
                                    .FirstOrDefaultAsync(lu => lu.Cpf == cpf);

            return entidade;
        }

        public async Task<IEnumerable<Lutador>?> Listar()
        {
            var entidades = await _dbContext.Lutador.AsNoTracking().ToListAsync();

            return entidades;
        }
    }
}
