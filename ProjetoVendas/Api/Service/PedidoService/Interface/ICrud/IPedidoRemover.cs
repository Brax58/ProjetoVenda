using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Service.PedidoService.Interface.ICrud
{
    public interface IPedidoRemover
    {
        Task Remover(Guid id);
    }
}
