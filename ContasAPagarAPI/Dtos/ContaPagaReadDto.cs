namespace ContasAPagarAPI.Dtos
{
    public class ContaPagaReadDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string ValorOriginalStr { get; set; }
        public string DataVencimentoStr { get; set; }
        public string DataPagamentoStr { get; set; }
        public string ValorCorrigido { get; set; }
        public int QuantidadeDiasAtraso { get; set; }
    }
}
