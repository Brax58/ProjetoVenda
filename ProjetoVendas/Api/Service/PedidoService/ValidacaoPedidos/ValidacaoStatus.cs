using Application.Service.PedidoService.Interface.IValidarPedidos;
using Domain.Entities;

namespace Application.Service.PedidoService.ValidacaoPedidos
{
    public class ValidacaoStatus : IValidacaoStatus
    {
        public bool EstadoStatus(Pedido pedido) {
            
            if (!(pedido.Status == Pedido.Statuss.aprovado))
                return true;
            else
                return false;

        }
    }
}
