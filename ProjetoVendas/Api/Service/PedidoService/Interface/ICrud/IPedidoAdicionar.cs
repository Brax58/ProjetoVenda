using Application.Request.Pedidos;
using System;
using System.Threading.Tasks;

namespace Application.Service.PedidoService.Interface.ICrud
{
    public interface IPedidoAdicionar
    {
        Task<Guid> Adicionar(AdicionarPedido adicionarPedido);
    }
}
