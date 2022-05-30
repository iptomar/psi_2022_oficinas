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

            // seed para a tabela gestores
            modelBuilder.Entity<Gestores>().HasData(
                new Gestores { GestorID = 1, Nome = "Gestor1", Email = "gestor1@mail.com" },
                new Gestores { GestorID = 2, Nome = "Gestor2", Email = "gestor2@mail.com" },
                new Gestores { GestorID = 3, Nome = "Gestor3", Email = "gestor3@mail.com" },
                new Gestores { GestorID = 4, Nome = "Gestor4", Email = "gestor4@mail.com" },
                new Gestores { GestorID = 5, Nome = "Gestor5", Email = "gestor5@mail.com" },
                new Gestores { GestorID = 6, Nome = "Gestor6", Email = "gestor6@mail.com" },
                new Gestores { GestorID = 7, Nome = "Gestor7", Email = "gestor7@mail.com" },
                new Gestores { GestorID = 8, Nome = "Gestor8", Email = "gestor8@mail.com" },
                new Gestores { GestorID = 9, Nome = "Gestor9", Email = "gestor9@mail.com" },
                new Gestores { GestorID = 10, Nome = "Gestor10", Email = "gestor10@mail.com" },
                new Gestores { GestorID = 11, Nome = "Gestor11", Email = "gestor11@mail.com" },
                new Gestores { GestorID = 12, Nome = "Gestor12", Email = "gestor12@mail.com" },
                new Gestores { GestorID = 13, Nome = "Gestor13", Email = "gestor13@mail.com" }
                );

            var listaServicos = new List<Serviços> {
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
            };


            modelBuilder.Entity<Serviços>().HasData(
                listaServicos
            );


            modelBuilder.Entity("OficinasServiços").HasData(
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 1, ["ListaServicosIdServ"] = 10 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 1, ["ListaServicosIdServ"] = 4 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 1, ["ListaServicosIdServ"] = 7 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 1, ["ListaServicosIdServ"] = 11 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 1, ["ListaServicosIdServ"] = 9 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 1, ["ListaServicosIdServ"] = 2 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 1, ["ListaServicosIdServ"] = 8 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 1, ["ListaServicosIdServ"] = 14 },

                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 2, ["ListaServicosIdServ"] = 1 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 2, ["ListaServicosIdServ"] = 2 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 2, ["ListaServicosIdServ"] = 3 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 2, ["ListaServicosIdServ"] = 5 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 2, ["ListaServicosIdServ"] = 6 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 2, ["ListaServicosIdServ"] = 7 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 2, ["ListaServicosIdServ"] = 4 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 2, ["ListaServicosIdServ"] = 8 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 2, ["ListaServicosIdServ"] = 9 },

                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 3, ["ListaServicosIdServ"] = 1 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 3, ["ListaServicosIdServ"] = 7 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 3, ["ListaServicosIdServ"] = 11 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 3, ["ListaServicosIdServ"] = 9 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 3, ["ListaServicosIdServ"] = 2 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 3, ["ListaServicosIdServ"] = 5 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 3, ["ListaServicosIdServ"] = 4 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 3, ["ListaServicosIdServ"] = 12 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 3, ["ListaServicosIdServ"] = 3 },

                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 4, ["ListaServicosIdServ"] = 1 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 4, ["ListaServicosIdServ"] = 2 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 4, ["ListaServicosIdServ"] = 10 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 4, ["ListaServicosIdServ"] = 5 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 4, ["ListaServicosIdServ"] = 3 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 4, ["ListaServicosIdServ"] = 7 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 4, ["ListaServicosIdServ"] = 11 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 4, ["ListaServicosIdServ"] = 13 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 4, ["ListaServicosIdServ"] = 6 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 4, ["ListaServicosIdServ"] = 8 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 4, ["ListaServicosIdServ"] = 4 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 4, ["ListaServicosIdServ"] = 9 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 4, ["ListaServicosIdServ"] = 14 },

                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 5, ["ListaServicosIdServ"] = 1 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 5, ["ListaServicosIdServ"] = 7 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 5, ["ListaServicosIdServ"] = 11 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 5, ["ListaServicosIdServ"] = 4 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 5, ["ListaServicosIdServ"] = 14 },

                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 6, ["ListaServicosIdServ"] = 1 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 6, ["ListaServicosIdServ"] = 7 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 6, ["ListaServicosIdServ"] = 11 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 6, ["ListaServicosIdServ"] = 6 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 6, ["ListaServicosIdServ"] = 8 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 6, ["ListaServicosIdServ"] = 9 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 6, ["ListaServicosIdServ"] = 4 },

                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 7, ["ListaServicosIdServ"] = 1 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 7, ["ListaServicosIdServ"] = 5 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 7, ["ListaServicosIdServ"] = 3 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 7, ["ListaServicosIdServ"] = 7 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 7, ["ListaServicosIdServ"] = 11 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 7, ["ListaServicosIdServ"] = 4 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 7, ["ListaServicosIdServ"] = 6 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 7, ["ListaServicosIdServ"] = 8 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 7, ["ListaServicosIdServ"] = 9 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 7, ["ListaServicosIdServ"] = 2 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 7, ["ListaServicosIdServ"] = 12 },

                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 8, ["ListaServicosIdServ"] = 1 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 8, ["ListaServicosIdServ"] = 2 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 8, ["ListaServicosIdServ"] = 4 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 8, ["ListaServicosIdServ"] = 10 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 8, ["ListaServicosIdServ"] = 5 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 8, ["ListaServicosIdServ"] = 3 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 8, ["ListaServicosIdServ"] = 7 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 8, ["ListaServicosIdServ"] = 11 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 8, ["ListaServicosIdServ"] = 13 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 8, ["ListaServicosIdServ"] = 6 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 8, ["ListaServicosIdServ"] = 8 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 8, ["ListaServicosIdServ"] = 9 },

                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 9, ["ListaServicosIdServ"] = 1 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 9, ["ListaServicosIdServ"] = 2 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 9, ["ListaServicosIdServ"] = 6 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 9, ["ListaServicosIdServ"] = 10 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 9, ["ListaServicosIdServ"] = 4 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 9, ["ListaServicosIdServ"] = 7 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 9, ["ListaServicosIdServ"] = 11 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 9, ["ListaServicosIdServ"] = 8 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 9, ["ListaServicosIdServ"] = 9 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 9, ["ListaServicosIdServ"] = 3 },

                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 10, ["ListaServicosIdServ"] = 1 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 10, ["ListaServicosIdServ"] = 4 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 10, ["ListaServicosIdServ"] = 7 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 10, ["ListaServicosIdServ"] = 11 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 10, ["ListaServicosIdServ"] = 9 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 10, ["ListaServicosIdServ"] = 5 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 10, ["ListaServicosIdServ"] = 3 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 10, ["ListaServicosIdServ"] = 13 },

                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 11, ["ListaServicosIdServ"] = 7 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 11, ["ListaServicosIdServ"] = 11 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 11, ["ListaServicosIdServ"] = 9 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 11, ["ListaServicosIdServ"] = 6 },

                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 12, ["ListaServicosIdServ"] = 1 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 12, ["ListaServicosIdServ"] = 14 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 12, ["ListaServicosIdServ"] = 10 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 12, ["ListaServicosIdServ"] = 7 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 12, ["ListaServicosIdServ"] = 11 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 12, ["ListaServicosIdServ"] = 8 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 12, ["ListaServicosIdServ"] = 9 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 12, ["ListaServicosIdServ"] = 2 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 12, ["ListaServicosIdServ"] = 5 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 12, ["ListaServicosIdServ"] = 4 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 12, ["ListaServicosIdServ"] = 3 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 12, ["ListaServicosIdServ"] = 6 },

                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 13, ["ListaServicosIdServ"] = 1 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 13, ["ListaServicosIdServ"] = 14 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 13, ["ListaServicosIdServ"] = 10 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 13, ["ListaServicosIdServ"] = 7 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 13, ["ListaServicosIdServ"] = 11 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 13, ["ListaServicosIdServ"] = 8 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 13, ["ListaServicosIdServ"] = 9 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 13, ["ListaServicosIdServ"] = 2 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 13, ["ListaServicosIdServ"] = 5 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 13, ["ListaServicosIdServ"] = 13 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 13, ["ListaServicosIdServ"] = 4 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 13, ["ListaServicosIdServ"] = 12 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 13, ["ListaServicosIdServ"] = 3 },
                new Dictionary<string, object> { ["ListaOficinasIdOficina"] = 13, ["ListaServicosIdServ"] = 6 }

                );


            modelBuilder.Entity<Oficinas>().HasData(
                new Oficinas
                {
                    IdOficina = 1,
                    Nome = "Boxcar Vulco Lisboa",
                    Morada = "Rua Fernão Mendes Pinto Lote M-T",
                    CodigoPostal = "1400 - 145",
                    Localidade = "Lisboa",
                    NumTelemovel = "912 360 073",
                    //Horario = "2ªfeira a Sábado: 08:30 - 19:00 Domingo: Fechado",
                    Imagem = "id1_boxcarvulcolisboa.jpg",
                    IdGestor = 1
                },


                new Oficinas
                {
                    IdOficina = 2,
                    Nome = "Confiauto Braga",
                    Morada = "Avenida Cidade do Porto n.º 182, Ferreiros",
                    CodigoPostal = "4705 - 084",
                    Localidade = "Braga",
                    NumTelemovel = "252 248 500",
                    //Horario = "2ªfeira a 6ªfeira: 08:30 - 18:00 Sábado: 09:00 - 13:00 Domingo: Fechado",
                    Imagem = "id2_braga.jpg",
                    IdGestor = 2
                },

                new Oficinas
                {
                    IdOficina = 3,
                    Nome = "Auto Arca D'Água 2",
                    Morada = "Rua 1º de Maio n.º 614B, Alfena",
                    CodigoPostal = "4445 - 245",
                    Localidade = "Valongo, Porto",
                    NumTelemovel = "229 689 811",
                    //Horario = "2ªfeira a 6ªfeira : 08:30 - 18:00 Sábado : 09:00 - 13:00 Domingo : Fechado",
                    Imagem = "id3_autoarcadgua2.jpg",
                    IdGestor = 3
                },

                new Oficinas
                {
                    IdOficina = 4,
                    Nome = "Manuel Jorge Santos Pereira",
                    Morada = "Rua Guilherme Gomes Fernandes n.º 1",
                    CodigoPostal = "2900 - 395",
                    Localidade = "Setúbal",
                    NumTelemovel = "921321817",
                    //Horario = "2ªfeira a 6ªfeira : 08:00 - 18:00 Sábado a Domingo : Fechado",
                    Imagem = "id4.jpg",
                    IdGestor = 4
                },

                new Oficinas
                {
                    IdOficina = 5,
                    Nome = "JSA",
                    Morada = "Rua 27 de Julho n.º 27, Trafaria",
                    CodigoPostal = "2825 - 895",
                    Localidade = "Almada, Setúbal",
                    NumTelemovel = "960 306 191",
                    //Horario = "2ªfeira a Sábado : 08:30 - 17:30 Domingo : Fechado",
                    Imagem = "id5_jsa.jpg",
                    IdGestor = 5
                },

                new Oficinas
                {
                    IdOficina = 6,
                    Nome = "MEIRICARRO",
                    Morada = "Rua das Covinhas, Santiago de Litém",
                    CodigoPostal = "3105-238",
                    Localidade = "Pombal, Leiria",
                    NumTelemovel = "236 948 477",
                    //Horario = "2ªfeira a 6ªfeira : 09:00 - 18:30 Sábado a Domingo : Fechado",
                    Imagem = "id6_meiricarro.jpg",
                    IdGestor = 6
                },

                new Oficinas
                {
                    IdOficina = 7,
                    Nome = "Automotorsport",
                    Morada = "Travassós de Baixo, Estrada São João da Carreira",
                    CodigoPostal = "3500-188",
                    Localidade = "Viseu",
                    NumTelemovel = "918 702 101",
                    //Horario = "2ªfeira a 6ªfeira : 09:00 - 18:30 Sábado : 09:00 - 12:30 Domingo : Fechado",
                    Imagem = "id7_automotor.jpg",
                    IdGestor = 7
                },

                new Oficinas
                {
                    IdOficina = 8,
                    Nome = "Auto Carapelhos",
                    Morada = "Rua da Floresta n.º 255, Carapelhos",
                    CodigoPostal = "3070-604",
                    Localidade = "Mira, Coimbra",
                    NumTelemovel = "231 451 782",
                    //Horario = "2ªfeira a 6ªfeira : 08:30 - 18:00 Sábado : 08:30 - 12:30 Domingo : Fechado",
                    Imagem = "id8.jpg",
                    IdGestor = 8
                },

                new Oficinas
                {
                    IdOficina = 9,
                    Nome = "Martinho Auto",
                    Morada = "Rua Doutor Hilário Barreiro Nunes Lote 26B, Zona Industrial",
                    CodigoPostal = "2005-002",
                    Localidade = "Santarém",
                    NumTelemovel = "243 302 228",
                    //Horario = "2ªfeira a 6ªfeira : 08:30 - 19:00 Sábado a Domingo : Fechado",
                    Imagem = "id9_martinho.jpg",
                    IdGestor = 9
                },

                new Oficinas
                {
                    IdOficina = 10,
                    Nome = "Auto Nogueiras",
                    Morada = "Zona Industrial Cabeço de Deus",
                    CodigoPostal = "2460-477",
                    Localidade = "Alcobaça, Leiria",
                    NumTelemovel = "262 585 252",
                    //Horario = "2ªfeira a 6ªfeira : 08:30 - 18:00 Sábado a Domingo : Fechado",
                    Imagem = "id10.jpg",
                    IdGestor = 10
                },

                new Oficinas
                {
                    IdOficina = 11,
                    Nome = "Corvauto",
                    Morada = "Rua Duarte Ludgero, Esgueira",
                    CodigoPostal = "3800-301",
                    Localidade = "Aveiro",
                    NumTelemovel = "234 303 150",
                    //Horario = "2ªfeira a 6ªfeira : 08:30 - 17:30 Sábado a Domingo : Fechado",
                    Imagem = "id11_corvauto.jpg",
                    IdGestor = 11
                },

                new Oficinas
                {
                    IdOficina = 12,
                    Nome = "Auto Imperial",
                    Morada = "Avenida das Cantarias n.º 130",
                    CodigoPostal = "5300-107",
                    //Distrito = "Bragança", 
                    //Concelho = "Bragança", 
                    Localidade = "Bragança",
                    NumTelemovel = "273 302 600",
                    // Horario = "2ªfeira a 6ªfeira : 08:30 - 18:00 Sábado a Domingo : Fechado",
                    Imagem = "id12.jpg",
                    IdGestor = 12
                },

                new Oficinas
                {
                    IdOficina = 13,
                    Nome = "Rino - Auto Alexandre",
                    Morada = "Cerro Cabeça de Câmara",
                    CodigoPostal = "8100-289",
                    Localidade = "Loulé, Faro",
                    NumTelemovel = "289 410 660",
                    //Horario = "2ªfeira a 6ªfeira : 08:30 - 18:00 Sábado : 08:30 - 13:00 Domingo : Fechado",
                    Imagem = "id13_rinoauto.jpg",
                    IdGestor = 13
                }
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
