using System.ComponentModel.DataAnnotations;

namespace psi_2022_oficinas.Models
{
    public class Oficinas
    {   
        public Oficinas()
        {
            ListaMarcacoes = new HashSet<Marcacoes>();
        }

        [Key]
        public int IdOficina { get; set; }
        
        [Required(ErrorMessage = "O nome é de preenchimento obrigatório.")]
        [StringLength(60,ErrorMessage = "O nome não pode ter mais do que 60 caracteres.")]
        
        public string Nome  { get; set; }

        [Required(ErrorMessage = "A morada é de preenchimento obrigatório.")]
        [StringLength(60,ErrorMessage ="A morada não pode ter mais do que 60 caracteres.")]
        public string Morada { get; set; }

        [Required(ErrorMessage ="O código postal é de preenchimento obrigatório.")]
        [StringLength(30, MinimumLength =8, ErrorMessage ="O código postal deve ter entre 8 a 30 caracteres.")]
        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; }

        [Required(ErrorMessage ="O número de telemóvel é de preenchimento obrigatório.")]
        [StringLength(14, MinimumLength = 9, ErrorMessage ="O número de telemóvel deve ter entre 9 a 14 caracteres.")]
        [RegularExpression("(00)?([0-9]{2,3})?[1-9][0-9]{8}", ErrorMessage = "Escreva, por favor, um nº de telemóvel com 9 algarismos. Se quiser, pode acrescentar o indicativo nacional e o internacional.")]
        [Display(Name = "Telemóvel")]
        public string   NumTelemovel { get; set; }
    }
}
