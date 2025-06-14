using ArtesMarciais.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtesMarciais.Infra
{
    public class ArtesMarciaisDbContext : DbContext
    {
        public ArtesMarciaisDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Lutador> Lutador { get; set; }
        public DbSet<PreparacaoLuta> PreparacaoLuta { get; set; }
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
