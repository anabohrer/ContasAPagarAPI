using System;
using System.ComponentModel.DataAnnotations;

namespace ContasAPagarAPI.Dtos
{
    public class ContaPagaCreateDto
    {
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [MaxLength(120)]
        public string Nome { get; set; }
        [Range(0.1, double.MaxValue, ErrorMessage = "O Valor Original precisa ser maior que zero")]
        public double ValorOriginal { get; set; }

        [Range(typeof(DateTime), "1/1/2015", "31/12/2022",
                 ErrorMessage = "Data de Vencimento precisa ser entre {0} {1:d} e {2:d}")]
        public DateTime DataVencimento { get; set; }
        [Range(typeof(DateTime), "1/1/2015", "31/12/2022",
                ErrorMessage = "Data de Pagamento precisa ser entre {0} {1:d} e {2:d}")]
        public DateTime DataPagamento { get; set; }

        public double ValorCorrigido
        {
            get
            {
                double valorCorrigido;
                if (QuantidadeDiasAtraso == 0)
                {
                    valorCorrigido = ValorOriginal;
                }
                else if (QuantidadeDiasAtraso > 0 && QuantidadeDiasAtraso <= 3)
                {
                    var juros = 0.02 + QuantidadeDiasAtraso * 0.001;
                    valorCorrigido = ValorOriginal + (ValorOriginal * juros);
                }
                else if (QuantidadeDiasAtraso > 3 && QuantidadeDiasAtraso <= 5)
                {
                    var juros = 0.03 + QuantidadeDiasAtraso * 0.002;
                    valorCorrigido = ValorOriginal + (ValorOriginal * juros);
                }
                else
                {
                    var juros = 0.05 + QuantidadeDiasAtraso * 0.003;
                    valorCorrigido = ValorOriginal + (ValorOriginal * juros);
                }

                return valorCorrigido;
            }
        }
        public int QuantidadeDiasAtraso
        {
            get
            {
                TimeSpan quantidadeDiasAtraso = DataPagamento - DataVencimento;
                if (quantidadeDiasAtraso.Days < 0)
                    return 0;
                else
                    return int.Parse(quantidadeDiasAtraso.Days.ToString());
            }
        }
    }
}
