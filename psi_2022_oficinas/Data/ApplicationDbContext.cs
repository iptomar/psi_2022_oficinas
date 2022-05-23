﻿using Microsoft.AspNetCore.Identity;
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

            modelBuilder.Entity<Serviços>().HasData(
                new Serviços { IdServ = 1, Servico = "Ar Condicionado" },
                new Serviços { IdServ = 2, Servico = "Estofos" },
                new Serviços { IdServ = 3, Servico = "Vidros" },
                new Serviços { IdServ = 4, Servico = "Mecânica" },
                new Serviços { IdServ = 5, Servico = "Pneus" },
                new Serviços { IdServ = 6, Servico = "Inspeção Periódica" },
                new Serviços { IdServ = 7, Servico = "Bate-chapas" },
                new Serviços { IdServ = 8, Servico = "Cortesia/Mobilidade" },
                new Serviços { IdServ = 9, Servico = "Eletricidade/Eletrónica" },
                new Serviços { IdServ = 10, Servico = "Lavagem" },
                new Serviços { IdServ = 11, Servico = "Pintura" },
                new Serviços { IdServ = 12, Servico = "Tuning" },
                new Serviços { IdServ = 13, Servico = "Assistência em Viagem" },
                new Serviços { IdServ = 14, Servico = "GPL Auto" }
            );
        }

        // Representar as Tabelas da BD
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Oficinas> Oficinas { get; set; }
        public DbSet<Marcacoes> Marcacoes { get; set; }
        public DbSet<Gestores> Gestores { get; set; }
        public DbSet<MetodoPagamento> MetodoPagamento { get; set; }
        public DbSet<Serviços> Serviços { get; set; }

    }
}
