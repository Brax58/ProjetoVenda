using Application.Service.PedidoService.Interface.ICrud;
using Domain.Entities;
using Infra.Data.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Application.Service.PedidoService
{
    public class PedidoObterPorId : IPedidoObterPorId
    {
        private readonly AppDbContext _appDbContext;

        public PedidoObterPorId(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Pedido> ObterId(Guid id)
        {
            try
            {
                return await _appDbContext.Pedidos.Include(x => x.Produtos).FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
