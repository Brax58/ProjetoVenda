using Application.Service.PedidoService.Interface.ICrud;
using Application.Service.PedidoService.Interface.IValidarPedidos;
using Domain.Entities;
using Infra.Data.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Application.Service.PedidoService
{
    public class PedidoRemover : IPedidoRemover
    {
        private readonly AppDbContext _appDbContext;
        private readonly IValidacaoStatus _ValidacaoStatus;

        public PedidoRemover(AppDbContext appDbContext, IValidacaoStatus validacaoStatus)
        {
            _appDbContext = appDbContext;
            _ValidacaoStatus = validacaoStatus;
        }

        public async Task Remover(Guid id)
        {
            try
            {
                var pedido = await _appDbContext.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
                if (_ValidacaoStatus.EstadoStatus(pedido)) {
                    throw new Exception("O pedido não pode ser apagado,pois está com com o status 'Aprovado'!.");
                }

                await Task.FromResult(_appDbContext.Set<Pedido>().Remove(pedido));

                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
