using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ContasAPagarAPI.Dtos
{
    public class ContaPagaCreateDto
    {
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [MaxLength(120)]
        public string Nome { get; set; }
        public string ValorOriginalStr { get; set; }
        [Range(0.1, double.MaxValue, ErrorMessage = "O Valor Original precisa ser maior que zero")]
        public double ValorOriginal => double.Parse(ValorOriginalStr, CultureInfo.GetCultureInfo("pt-BR"));
        public string DataVencimentoStr { get; set; }
        [Range(typeof(DateTime), "2015-01-01", "2022-12-31", ErrorMessage = "Datas precisam ser entre 2015 e 2022")]
        public DateTime DataVencimento => DateTime.Parse(DataVencimentoStr);

        public string DataPagamentoStr { get; set; }
        [Range(typeof(DateTime), "2015-01-01", "2022-12-31", ErrorMessage = "Datas precisam ser entre 2015 e 2022")]
        public DateTime DataPagamento => DateTime.Parse(DataPagamentoStr);

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
