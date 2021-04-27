using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.Interfaces.Crud.Pedidos.PedidoAtualizar
{
    public interface IPedidoAtualizar
    {
        Task Atualizar(AtualizarPedido atualizarPedido);
    }
}
