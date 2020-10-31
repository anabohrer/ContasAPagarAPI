namespace ContasAPagarAPI.Dtos
{
    public class ContaPagaReadDto
    {
        public string Nome { get; set; }
        public double ValorOriginal { get; set; }
        public string DataVencimento { get; set; }
        public string DataPagamento { get; set; }
        public double ValorCorrigido { get; set; }
        public int QuantidadeDiasAtraso { get; set; }
    }
}
