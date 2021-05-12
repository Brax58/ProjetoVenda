using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Service.PedidoService.Interface.ICrud
{
    public interface IPedidoObterPorId
    {
        Task<Pedido> ObterId(Guid id);
    }
}
