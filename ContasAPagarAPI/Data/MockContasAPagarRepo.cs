﻿using ContasAPagarAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContasAPagarAPI.Data
{
    public class MockContasAPagarRepo : IContasAPagarRepo
    {
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
    }
}
