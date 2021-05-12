using Domain.Entities;

namespace Application.Service.PedidoService.Interface.IValidarPedidos
{
    public interface IValidacaoStatus
    {
        bool EstadoStatus(Pedido pedido);
    }
}
