using System;

namespace ContasAPagarAPI.Models
{
    public class ContaPaga : Conta
    {
        public DateTime DataPagamento { get; set; }
        public double ValorCorrigido { get; set; }
        public int QuantidadeDiasAtraso { get; set; }
    }
}
