using Application.Request.Pedidos;
using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Service.ProdutoService.Interface.ICrud
{
    public interface IProdutoObterPorId
    {
        Task<Produto> ObterId(Guid id);
    }
}
