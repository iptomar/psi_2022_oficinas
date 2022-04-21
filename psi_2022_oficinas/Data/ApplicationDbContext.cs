using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace psi_2022_oficinas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(model);

            // insert DB seed

            modelBuilder.Entity<MetodoPagamento>().HasData(
                new MetodoPagamento { IdPagamento = 0, TipoPagamento = "" },
                new MetodoPagamento { IdPagamento = 1, TipoPagamento = "" },
                new MetodoPagamento { IdPagamento = 2, TipoPagamento = "" }
            );
        }

        // Representar as Tabelas da BD
        public DbSet<Clientes> Clientes { get; set; }
    }
}