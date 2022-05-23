using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace psi_2022_oficinas.Models
{
    /// <summary>
    /// Classe para filtrar oficinas por localidade e 
    /// </summary>
    public class OficinaLocalViewModel
    {
        /// <summary>
        /// Lista de oficinas
        /// </summary>
        public List<Oficinas>? Oficinas { get; set; }
        /// <summary>
        /// Lista de localidades. Permite ao utilizador selecionar.
        /// </summary>
        public SelectList? Localidades { get; set; }
        // Armazena a string de parametro de filtro para a localidade
        public string? Local { get; set; }
        // Armazena a string de parametro de filtro para o nome
        public string? Nome { get; set; }
    }
}

