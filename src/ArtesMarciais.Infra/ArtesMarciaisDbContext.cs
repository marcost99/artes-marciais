using ArtesMarciais.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtesMarciais.Infra
{
    public class ArtesMarciaisDbContext : DbContext
    {
        public ArtesMarciaisDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Lutador> Lutador { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
