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
            await _dbContext.Lutador.AddAsync(lutador);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lutador>?> Listar()
        {
            var entidades = await _dbContext.Lutador.AsNoTracking().ToListAsync();

            return entidades;
        }
    }
}
