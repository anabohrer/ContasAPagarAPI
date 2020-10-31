using ContasAPagarAPI.Models;
using System;
using System.Collections.Generic;

namespace ContasAPagarAPI.Data
{
    public class MockContasAPagarRepo : IContasAPagarRepo
    {
        public void AtualizaContaCadastrada(ContaPaga conta)
        {
            throw new NotImplementedException();
        }

        public ContaPaga BuscaContaCadastrada(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContaPaga> BuscaContasCadastradas()
        {
            IEnumerable<ContaPaga> contaCadastradas = new List<ContaPaga>()
            {
                new ContaPaga() { Id = 1, Nome = "Renner", ValorOriginal = 30.00, ValorCorrigido = 30.66, QuantidadeDiasAtraso = 2, DataVencimento = DateTime.Now.AddDays(-2), DataPagamento = DateTime.Now},
                new ContaPaga() { Id = 1, Nome = "Gaston", ValorOriginal = 30.00, ValorCorrigido = 30.66, QuantidadeDiasAtraso = 2, DataVencimento = DateTime.Now.AddDays(-2), DataPagamento = DateTime.Now},
                new ContaPaga() { Id = 1, Nome = "C&A", ValorOriginal = 30.00, ValorCorrigido = 30.66, QuantidadeDiasAtraso = 2, DataVencimento = DateTime.Now.AddDays(-2), DataPagamento = DateTime.Now},
                new ContaPaga() { Id = 1, Nome = "Riachuelo", ValorOriginal = 30.00, ValorCorrigido = 30.66, QuantidadeDiasAtraso = 2, DataVencimento = DateTime.Now.AddDays(-2), DataPagamento = DateTime.Now},
                new ContaPaga() { Id = 1, Nome = "Marisa", ValorOriginal = 30.00, ValorCorrigido = 30.66, QuantidadeDiasAtraso = 2, DataVencimento = DateTime.Now.AddDays(-2), DataPagamento = DateTime.Now},
                new ContaPaga() { Id = 1, Nome = "Gang", ValorOriginal = 30.00, ValorCorrigido = 30.66, QuantidadeDiasAtraso = 2, DataVencimento = DateTime.Now.AddDays(-2), DataPagamento = DateTime.Now}
            };
            return contaCadastradas;
        }

        public void CriarConta(ContaPaga conta)
        {
            throw new NotImplementedException();
        }

        public void DeletarContaCadastrada(ContaPaga conta)
        {
            throw new NotImplementedException();
        }

        public bool SalvarMudancas()
        {
            throw new NotImplementedException();
        }
    }
}
