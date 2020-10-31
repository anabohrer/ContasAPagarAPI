using ContasAPagarAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContasAPagarAPI.Data
{
    public class ContasAPagarRepo : IContasAPagarRepo
    {
        private readonly ContasAPagarContext _context;

        public ContasAPagarRepo(ContasAPagarContext context)
        {
            _context = context;
        }
        public IEnumerable<ContaPaga> BuscaContasCadastradas()
        {
            return _context.Contas.ToList();
        }
    }
}
