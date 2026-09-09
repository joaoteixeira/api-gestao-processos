using ApiGestaoProcessos.Entities;
using ApiGestaoProcessos.Enums;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoProcessos.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Processo> Processos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Processo>()
                .Property(e => e.Situacao)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<SituacaoEnum>(v));
        }

    }
}
