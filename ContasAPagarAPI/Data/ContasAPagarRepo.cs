using ContasAPagarAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContasAPagarAPI.Data
{
    public class ContasAPagarRepo : IContasAPagarRepo
    {
        private readonly ContasAPagarContext _context;

        public ContasAPagarRepo(ContasAPagarContext context)
        {
            _context = context;
        }

        public void AtualizaContaCadastrada(ContaPaga conta)
        {
           //Implementação vazia
        }

        public ContaPaga BuscaContaCadastrada(int id)
        {
            return _context.Contas.FirstOrDefault(conta => conta.Id == id);
        }

        public IEnumerable<ContaPaga> BuscaContasCadastradas()
        {
            return _context.Contas.ToList().OrderBy(x => x.Id);
        }

        public void CriarConta(ContaPaga conta)
        {
            if (conta == null)
            {
                throw new ArgumentNullException(nameof(conta));
            }

            _context.Contas.Add(conta);
            _context.SaveChanges();
        }

        public void DeletarContaCadastrada(ContaPaga conta)
        {
            if (conta == null)
            {
                throw new ArgumentNullException(nameof(conta));
            }
            _context.Contas.Remove(conta);
            _context.SaveChanges();
        }

        public bool SalvarMudancas()
        {
           return  _context.SaveChanges() >= 0;
        }
    }
}
