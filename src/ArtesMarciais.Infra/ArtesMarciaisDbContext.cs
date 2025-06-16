using ArtesMarciais.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtesMarciais.Infra
{
    public class ArtesMarciaisDbContext : DbContext
    {
        public ArtesMarciaisDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Lutador> Lutador { get; set; }
        public DbSet<PreparacaoLuta> PreparacaoLuta { get; set; }
        public DbSet<Campeonato> Campeonato { get; set; }
        public DbSet<LutadorCampeonato> LutadorCampeonato { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento entre Lutador e PreparacaoLuta (inicial)
            modelBuilder.Entity<Lutador>()
                .HasOne(l => l.PreparacaoLutaInicial)
                .WithMany() // Sem referência inversa em PreparacaoLuta
                .HasForeignKey(l => l.IdPreparacaoLutaInicial)
                .OnDelete(DeleteBehavior.Restrict); // Evita exclusão em cascata

            // Relacionamento entre Lutador e PreparacaoLuta (final)
            modelBuilder.Entity<Lutador>()
                .HasOne(l => l.PreparacaoLutaFinal)
                .WithMany() // Sem referência inversa em PreparacaoLuta
                .HasForeignKey(l => l.IdPreparacaoLutaFinal)
                .OnDelete(DeleteBehavior.Restrict); // Evita exclusão indesejada

            modelBuilder.Entity<LutadorCampeonato>()
                .HasKey(lc => new { lc.LutadorId, lc.CampeonatoId });

            modelBuilder.Entity<LutadorCampeonato>()
                .HasOne(lc => lc.Lutador)
                .WithMany(l => l.LutadorCampeonato)
                .HasForeignKey(lc => lc.LutadorId);

            modelBuilder.Entity<LutadorCampeonato>()
                .HasOne(lc => lc.Campeonato)
                .WithMany(c => c.LutadorCampeonato)
                .HasForeignKey(lc => lc.CampeonatoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
