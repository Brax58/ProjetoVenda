using Application.Request.Produtos;
using System;
using System.Threading.Tasks;

namespace Application.Service.ProdutoService.Interface.ICrud
{
    public interface IProdutoAdicionar
    {
        Task<Guid> Adicionar(AdicionarProduto adicionarProduto);
    }
}
