using ApiGestaoProcessos.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoProcessos.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Processo> Processos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Marcacao> Marcacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração do relacionamento muitos-para-muitos (N:N)
            // entre Processo e Marcacao, criando a tabela de junção "processos_marcacoes"
            modelBuilder.Entity<Processo>()
                .HasMany(p => p.Marcacoes)
                .WithMany(m => m.Processos)
                .UsingEntity<Dictionary<string, object>>(
                    "ProcessoMarcacao",
                    f => f.HasOne<Marcacao>().WithMany().HasForeignKey("marcacao_id"),
                    f => f.HasOne<Processo>().WithMany().HasForeignKey("processo_id"),
                    f => f.ToTable("processos_marcacoes")
                );
        }

    }
}
