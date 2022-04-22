namespace psi_2022_oficinas.Models
{
    public class Marcacoes
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = Data de Nascimento)]
        public DateTime DataPedido { get; set; }

        [ForeignKey(nameof(Pagamento)] 
        public int IdPagamento { get; set; }


        [ForeignKey(nameof(Clientes)]
        public int IdCliente { get; set; }

        [ForeignKey(nameof(Oficinas)]
        public int IdOficina { get; set; }

        public int IdMarcacao { get; set; }

        public Pagamento pagamento { get; set; }

        public String ClassServico { get; set; }

        public String EstadoServico { get; set; }

        public String Descricao { get; set; }

        public String Caucao { get; set; }

        



    }
}
