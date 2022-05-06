using Microsoft.AspNetCore.Identity;
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

            // adicionar os Roles
            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole { Id = "C", Name = "Cliente", NormalizedName = "CLIENTE" },
               new IdentityRole { Id = "A", Name = "Admin", NormalizedName = "ADMIN" },
               new IdentityRole { Id = "G", Name = "Gestor", NormalizedName = "GESTOR" }
            );

            //insert DB seed

            modelBuilder.Entity<MetodoPagamento>().HasData(
                new MetodoPagamento { IdPagamento = 1, TipoPagamento = "Multibanco" },
                new MetodoPagamento { IdPagamento = 2, TipoPagamento = "MBway" },
                new MetodoPagamento { IdPagamento = 3, TipoPagamento = "Cartão de Crédito" }

                );


            // seed para a tabela gestores
            modelBuilder.Entity<Gestores>().HasData(
                new Gestores { GestorID = 1, Nome = "Gestor1", Email = "gestor1@mail.com" },
                new Gestores { GestorID = 2, Nome = "Gestor2", Email = "gestor2@mail.com" },
                new Gestores { GestorID = 3, Nome = "Gestor3", Email = "gestor3@mail.com" }
                ) ;

        }

        // Representar as Tabelas da BD
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Oficinas> Oficinas { get; set; }
        public DbSet<Marcacoes> Marcacoes { get; set; }
        public DbSet<Gestores> Gestores { get; set; }
        public DbSet<MetodoPagamento> MetodoPagamento { get; set; }

    }
}