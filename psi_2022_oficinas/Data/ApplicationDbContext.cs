using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using psi_2022_oficinas.Models;

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
            base.OnModelCreating(modelBuilder);

            //insert DB seed

            //modelBuilder.Entity<MetodoPagamento>().HasData(
            //    new MetodoPagamento { IdPagamento = 0, TipoPagamento = "MB" },
            //    new MetodoPagamento { IdPagamento = 1, TipoPagamento = "MB" },
            //    new MetodoPagamento { IdPagamento = 2, TipoPagamento = "MB" }
            //    new MetodoPagamento { IdPagamento = 2, TipoPagamento = "MB" }

            //    );
            //modelBuilder.Entity<Clientes>().HasData(
            //    new Clientes { IdClientes = 0, PrimeiroNome = "" },
               
            //    );

        }

        // Representar as Tabelas da BD
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Oficinas> Oficinas { get; set; }
        public DbSet<Marcacoes> Marcacoes { get; set; }
        public DbSet<Gestores> Gestores { get; set; }
        public DbSet<MetodoPagamento> MetodoPagamento { get; set; }

    }
}