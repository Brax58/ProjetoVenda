using Application.Request.Pedidos;
using Application.Request.Produtos;
using Application.Service.ProdutoService.Interface.IAtualizacaoDoProdutos;
using Domain.Entities;

namespace Application.Service.ProdutoService.AtualizacaoDoProduto
{
    public class AtualizacaoDoProduto : IAtualizacaoDoProduto
    {
        public void AtualizarProduto(Produto produto, AtualizarProduto atualizarProduto)
        {
            produto.AddNewProduto(atualizarProduto.Descricao, atualizarProduto.Valor, atualizarProduto.QuantidadeNoEstoque,atualizarProduto.Ativo);
        }
    }
}
