using ContasAPagarAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContasAPagarAPI.Data
{
    public interface IContasAPagarRepo
    {
        IEnumerable<ContaPaga> BuscaContasCadastradas();
    }
}
