using ProjetoVendas.Entities;
using ProjetoVendas.Resquest.Produto;
using ProjetoVendas.Service.Interfaces.Atualizar;

namespace ProjetoVendas.Service.AtualizacaoDasEntidades
{
    public class AtualizacaoDoProduto : IAtualizacaoDoProduto
    {
        public void AtualizarProduto(Produto produto, AtualizarProduto atualizarProduto)
        {
            produto.AddNewProduto(atualizarProduto.Descricao, atualizarProduto.Valor, atualizarProduto.QuantidadeNoEstoque);
        }
    }
}
