﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace psi_2022_oficinas.Models
{
    public class Oficinas
    {
        public Oficinas()
        {
            ListaMarcacoes = new HashSet<Marcacoes>();
        }

        /// <summary>
        /// Identificador da Oficina
        /// </summary>
        [Key]
        public int IdOficina { get; set; }

        /// <summary>
        /// Nome da Oficina
        /// </summary>
        [Required(ErrorMessage = "O nome é de preenchimento obrigatório.")]
        [StringLength(60, ErrorMessage = "O nome não pode ter mais do que 60 caracteres.")]
        public string Nome { get; set; }

        /// <summary>
        /// Imagem da oficina
        /// </summary>
        public string Imagem { get; set; }

        /// <summary>
        /// Morada da Oficina
        /// </summary>
        [Required(ErrorMessage = "A morada é de preenchimento obrigatório.")]
        [StringLength(60, ErrorMessage = "A morada não pode ter mais do que 60 caracteres.")]
        public string Morada { get; set; }

        /// <summary>
        /// Localidade da oficina
        /// </summary>
        [Required(ErrorMessage = "A localiade é de preenchimento obrigatório.")]
        [StringLength(30, ErrorMessage = "A localidade não pode ter mais do que 30 caracteres.")]
        public string Localidade { get; set; }

        /// <summary>
        /// Código Postal da Oficina
        /// </summary>
        [Required(ErrorMessage = "O código postal é de preenchimento obrigatório.")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "O código postal deve ter entre 8 a 30 caracteres.")]
        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; }

        /// <summary>
        /// Número de Telemóvel da Oficina
        /// </summary>
        [Required(ErrorMessage = "O número de telemóvel é de preenchimento obrigatório.")]
        [StringLength(14, MinimumLength = 9, ErrorMessage = "O número de telemóvel deve ter entre 9 a 14 caracteres.")]
        [RegularExpression("(00)?([0-9]{2,3})?[1-9][0-9]{8}", ErrorMessage = "Escreva, por favor, um nº de telemóvel com 9 algarismos. Se quiser, pode acrescentar o indicativo nacional e o internacional.")]
        [Display(Name = "Telemóvel")]
        public string NumTelemovel { get; set; }

        //################################ FOREIGN KEY #####################################

        /// <summary>
        /// Gestor que gere a Oficina
        /// </summary>
        [ForeignKey(nameof(Gestor))]
        public int IdGestor { get; set; }
        public Gestores Gestor { get; set; }

        //##################################################################################

        /// <summary>
        /// Marcações na Oficina
        /// </summary>
        public ICollection<Marcacoes> ListaMarcacoes { get; set; }
    }
}
