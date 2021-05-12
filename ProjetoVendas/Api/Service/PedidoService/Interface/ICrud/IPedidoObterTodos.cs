using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Service.PedidoService.Interface.ICrud
{
    public interface IPedidoObterTodos
    {
        Task<List<Pedido>> ObterTodos();
    }
}
