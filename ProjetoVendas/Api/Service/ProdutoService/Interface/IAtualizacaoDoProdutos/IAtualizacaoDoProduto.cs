using Application.Request.Pedidos;
using Application.Request.Produtos;
using Domain.Entities;

namespace Application.Service.ProdutoService.Interface.IAtualizacaoDoProdutos
{
    public interface IAtualizacaoDoProduto
    {
        void AtualizarProduto(Produto produto, AtualizarProduto atualizarProduto);
    }
}
        