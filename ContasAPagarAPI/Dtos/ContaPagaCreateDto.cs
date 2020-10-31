using System;
using System.ComponentModel.DataAnnotations;

namespace ContasAPagarAPI.Dtos
{
    public class ContaPagaCreateDto
    {
        [Required]
        [MaxLength(120)]
        public string Nome { get; set; }
        public double ValorOriginal { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public double ValorCorrigido { get; set; }
        public int QuantidadeDiasAtraso { get; set; }
    }
}
