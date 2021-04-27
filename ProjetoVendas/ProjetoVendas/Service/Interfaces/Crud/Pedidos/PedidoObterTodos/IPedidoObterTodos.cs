using ProjetoVendas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.Interfaces.Crud.Pedidos.PedidoObterTodos
{
    public interface IPedidoObterTodos
    {
        Task<List<Pedido>> ObterTodos();
    }
}
