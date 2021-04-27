using ProjetoVendas.Resquest.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.Interfaces.Crud.Pedidos.PedidoAdicionar
{
    public interface IPedidoAdicionar
    {
        Task<Guid> Adicionar(AdicionarPedido adicionarPedido);
    }
}
