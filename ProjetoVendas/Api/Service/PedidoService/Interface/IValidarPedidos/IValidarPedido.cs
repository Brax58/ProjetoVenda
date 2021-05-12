using Application.Request.Pedidos;

namespace Application.Service.PedidoService.Interface.IValidarPedidos
{
    public interface IValidarPedido
    {
        bool ValidarCaracteristicaPedido(AdicionarPedido adicionarPedido);
    }
}
