using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using psi_2022_oficinas.Models;

namespace psi_2022_oficinas.Data
{
    /// <summary>
    /// classe para recolher os dados particulares dos Utilizadores
    /// vamos deixar de usar o 'IdentityUser' e começar a usar este
    /// A adição desta classe implica:
    ///    - mudar a classe de criação da Base de Dados
    ///    - mudar no ficheiro 'startup.cs' a referência ao tipo do utilizador
    ///    - mudar em todos os ficheiros do projeto a referência a 'IdentityUser' 
    ///           para 'ApplicationUser'
    /// </summary>
    public class ApplicationUser : IdentityUser
    {

        /// <summary>
        /// recolhe a data de registo de um utilizador
        /// </summary>
        public DateTime DataRegisto { get; set; }

        // /// <summary>
        // /// se fizerem isto, estão a adicionar todos os atributos do 'Cliente'
        // /// à tabela de autenticação
        // /// </summary>
        // public Clientes Cliente { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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

            // sedd tabela MetodoPagamento
            modelBuilder.Entity<MetodoPagamento>().HasData(
                new MetodoPagamento { IdPagamento = 1, TipoPagamento = "Multibanco" },
                new MetodoPagamento { IdPagamento = 2, TipoPagamento = "MBway" },
                new MetodoPagamento { IdPagamento = 3, TipoPagamento = "Cartão de Crédito" }

                );

            // seed tabela gestores
            modelBuilder.Entity<Gestores>().HasData(
                new Gestores { GestorID = 1, Nome = "Gestor1", Email = "gestor1@mail.com" },
                new Gestores { GestorID = 2, Nome = "Gestor2", Email = "gestor2@mail.com" },
                new Gestores { GestorID = 3, Nome = "Gestor3", Email = "gestor3@mail.com" }
                );

            // seed tabela oficinas
            modelBuilder.Entity<Oficinas>().HasData(
                    new Oficinas
                    {
                        IdOficina = 1,
                        Nome = "Aral",
                        Imagem = "aral.png",
                        Morada = "Avenida Condestável Dom Nuno Álvares Pereira, 2",
                        Localidade = "Tomar",
                        CodigoPostal = "2300-532",
                        NumTelemovel = "249310070",
                        IdGestor = 1
                    },
                    new Oficinas
                    {
                        IdOficina = 2,
                        Nome = "Auto Ideal do Nabao",
                        Imagem = "autoidealnabao.png",
                        Morada = "Lugar do Alvito",
                        Localidade = "Tomar",
                        CodigoPostal = "2300-310",
                        NumTelemovel = "249310810",
                        IdGestor = 2
                    },
                     new Oficinas
                     {
                         IdOficina = 3,
                         Nome = "Auto Barreiro",
                         Imagem = "autobarreiro.png",
                         Morada = " Estrada Barreiro 3 - B",
                         Localidade = "Tomar",
                         CodigoPostal = "2300-442",
                         NumTelemovel = "249316896",
                         IdGestor = 3
                     }
                );
        }

        // Representar as Tabelas da BD
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Oficinas> Oficinas { get; set; }
        public DbSet<Marcacoes> Marcacoes { get; set; }
        public DbSet<Gestores> Gestores { get; set; }
        public DbSet<MetodoPagamento> MetodoPagamento { get; set; }

    }
}
