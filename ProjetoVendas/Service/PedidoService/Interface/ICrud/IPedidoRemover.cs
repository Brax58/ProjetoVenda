using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.Interfaces.Crud.Pedidos.PedidoRemover
{
    public interface IPedidoRemover
    {
        Task Remover(Guid id);
    }
}
