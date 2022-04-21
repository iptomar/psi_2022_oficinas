using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace psi_2022_oficinas.Models
{
    public class MetodoPagamento
    {

        /// <summary>
        /// Identificador do Pagamento
        /// </summary>
        [Key]
        public int IdPagamento { get; set; }

        /// <summary>
        /// Tipo de Pagamento
        /// </summary>
        public string TipoPagamento { get; set; }

    }
}
