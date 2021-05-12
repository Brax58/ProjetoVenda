using Application.Request.Pedidos;
using System.Threading.Tasks;

namespace Application.Service.PedidoService.Interface.ICrud
{
    public interface IPedidoAtualizar
    {
        Task Atualizar(AtualizarPedido atualizarPedido);
    }
}
