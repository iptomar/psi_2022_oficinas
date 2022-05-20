using System.ComponentModel.DataAnnotations;

namespace psi_2022_oficinas.Models
{
    public class Serviços
    {

        public Serviços()
        {
            ListaOficinas = new HashSet<Oficinas>();
        }

        //##################################################################################

        /// <summary>
        /// Identificador do Serviço
        /// </summary>
        [Key]
        public int IdServ { get; set; }
        
        /// <summary>
        /// Tipo de Serviço
        /// </summary>
        public String Servico { get; set; }

        //##################################################################################

        /// <summary>
        /// Lista de Oficinas
        /// </summary>
        public ICollection<Oficinas> ListaOficinas { get; set; }

    }
}
