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

        public async Task<List<LutadorCampeonato>> AtualizaLutadorCampeonato(List<LutadorCampeonato> lutadorCampeonatos)
        {
            List<LutadorCampeonato> lutadorCampeonatoAtualizado = new();
            foreach (var lutadorCampeonato in lutadorCampeonatos)
            {
                var campeonatoExistente = await _dbContext.Campeonato
                    .FirstOrDefaultAsync(c => c.Nome == lutadorCampeonato.Campeonato.Nome);

                if (campeonatoExistente != null)
                {
                    campeonatoExistente.Localidade = lutadorCampeonato.Campeonato.Localidade;
                    campeonatoExistente.DataRealizacao = lutadorCampeonato.Campeonato.DataRealizacao;
                    _dbContext.Entry(campeonatoExistente).State = EntityState.Modified;
                    lutadorCampeonatoAtualizado.Add(new LutadorCampeonato { LutadorId = lutadorCampeonato.Lutador.Id, Lutador = lutadorCampeonato.Lutador, CampeonatoId = campeonatoExistente.Id, Campeonato = campeonatoExistente });
                }
                else
                {
                    await _dbContext.Campeonato.AddAsync(lutadorCampeonato.Campeonato);
                    lutadorCampeonatoAtualizado.Add(new LutadorCampeonato { LutadorId = lutadorCampeonato.Lutador.Id, Lutador = lutadorCampeonato.Lutador, Campeonato = lutadorCampeonato.Campeonato });
                }
            }
            return lutadorCampeonatoAtualizado;
        }
    }
}
