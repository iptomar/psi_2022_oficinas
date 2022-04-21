using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace psi_2022_oficinas.Models
{
    public class Gestores
    {
        [Required]
        public int GestorID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O primeiro nome não pode conter mais que 50 letras.\n Se for necessário abrevie o seu nome.")]
        [Column("PrimeiroNome")]
        [Display(Name = "Primeiro Nome")]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public Object Email { get; set; }

    }
}
