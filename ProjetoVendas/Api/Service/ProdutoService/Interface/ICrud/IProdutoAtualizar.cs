using Application.Request.Produtos;
using System.Threading.Tasks;

namespace Application.Service.ProdutoService.Interface.ICrud
{
    public interface IProdutoAtualizar
    {
        Task Atualizar(AtualizarProduto atualizarProduto);
    }
}
