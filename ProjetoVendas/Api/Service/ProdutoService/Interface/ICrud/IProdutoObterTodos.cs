using Application.Request.Pedidos;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Service.ProdutoService.Interface.ICrud
{
    public interface IProdutoObterTodos
    {
        Task<List<Produto>> ObterTodos();
    }
}
