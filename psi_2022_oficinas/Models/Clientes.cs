using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace psi_2022_oficinas.Models
{
    public class Clientes
    {
        [Key]
        public int IdClientes { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O primeiro nome não pode conter mais que 50 letras.\n Se for necessário abrevie o seu nome.")]
        [Column("PrimeiroNome")]
        [Display(Name = "Primeiro Nome")]
        public string PrimeiroNome { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "O primeiro nome não pode conter mais que 50 letras.\n Se for necessário abrevie o seu nome.")]
        [Column("Apelido")]
        [Display(Name = "Apelido")]
        public string Apelido { get; set; }

        public String NomeCliente
        {
            get { return PrimeiroNome +" "+ Apelido; }
        }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNasc { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public Object Email { get; set; }

        [Required]
        [StringLength(9)]
        [DisplayFormat(DataFormatString = "{0-9}", ApplyFormatInEditMode= true)]
        public string NIF { get; set; }

        [Required]
        [StringLength(9)]
        [DisplayFormat(DataFormatString = "{0-9}", ApplyFormatInEditMode = true)]
        public string NCartaConducao { get; set; }

        [Required]
        [StringLength(50)]
        public string Morada { get; set; }

        [Required]
        [StringLength(9)]
        [DisplayFormat(DataFormatString = "{0-9}", ApplyFormatInEditMode = true)]
        public string Ntelemovel { get; set; }


        public ICollection<Marcacoes> ListaMarcacoes { get; set; }

    }
}
