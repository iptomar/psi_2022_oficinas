using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace psi_2022_oficinas.Models
{
    public class Marcacoes
    {

        /// <summary>
        /// Identificador da Marcação
        /// </summary>
        [Key]
        public int IdMarcacao { get; set; }

        /// <summary>
        /// Data de Pedido da Marcação
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Marcação")]
        public DateTime DataPedido { get; set; }

        /// <summary>
        /// Classe do Serviço
        /// </summary>
        public String ClassServico { get; set; }

        /// <summary>
        /// Estado do Serviço
        /// </summary>
        public String EstadoServico { get; set; }

        /// <summary>
        /// Descrição
        /// </summary>
        public String Descricao { get; set; }

        /// <summary>
        /// Caução
        /// </summary>
        public String Caucao { get; set; }

        //################################ FOREIGN KEY #####################################

        /// <summary>
        /// Método de Pagamento
        /// </summary>
        [ForeignKey(nameof(Pagamento))] 
        public int IdPagamento { get; set; }
        public MetodoPagamento Pagamento { get; set; }

        /// <summary>
        /// Cliente que efetua o pedido de marcação
        /// </summary>
        [ForeignKey(nameof(Cliente))]
        public int IdCliente { get; set; }
        public Clientes Cliente { get; set; }

        /// <summary>
        /// Oficina na qual o cliente pretende a marcação
        /// </summary>
        [ForeignKey(nameof(Oficina))]
        public int IdOficina { get; set; }
        public Oficinas Oficina { get; set; }

    }
}
