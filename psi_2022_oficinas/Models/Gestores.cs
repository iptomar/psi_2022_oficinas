using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace psi_2022_oficinas.Models
{
    public class Gestores
    {
        /// <summary>
        /// Identificador do Gestor
        /// </summary>
        [Required]
        [Key]
        public int GestorID { get; set; }

        /// <summary>
        /// Nome do Gestor
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "O primeiro nome não pode conter mais que 50 letras.\n Se for necessário abrevie o seu nome.")]
        [Column("PrimeiroNome")]
        [Display(Name = "Primeiro Nome")]
        public string Nome { get; set; }

        /// <summary>
        /// Email do Gestor
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        public Object Email { get; set; }

    }
}
