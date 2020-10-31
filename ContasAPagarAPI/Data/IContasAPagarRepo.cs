using ContasAPagarAPI.Models;
using System.Collections.Generic;

namespace ContasAPagarAPI.Data
{
    public interface IContasAPagarRepo
    {
        bool SalvarMudancas();

        IEnumerable<ContaPaga> BuscaContasCadastradas();
        ContaPaga BuscaContaCadastrada(int id);
        void CriarConta(ContaPaga conta);
        void AtualizaContaCadastrada(ContaPaga conta);
        void DeletarContaCadastrada(ContaPaga conta);
    }
}
