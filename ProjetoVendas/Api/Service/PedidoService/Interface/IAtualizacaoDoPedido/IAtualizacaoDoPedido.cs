using Application.Request.Pedidos;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Service.PedidoService.Interface.IAtualizacaoDoPedido
{
    public interface IAtualizacaoDoPedido
    {
        Task AtualizarProdutos(AtualizarPedido atualizarPedido, Pedido pedido);
    }
}
