using ProjetoVendas.Resquest.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.Interfaces.Validar.IValidarPedidos
{
    public interface IValidarPedido
    {
        bool ValidarCaracteristicaPedido(AdicionarPedido adicionarPedido);
    }
}
