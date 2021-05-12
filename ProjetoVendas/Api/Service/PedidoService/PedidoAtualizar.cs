using Application.Request.Pedidos;
using Application.Service.PedidoService.Interface.IAtualizacaoDoPedido;
using Application.Service.PedidoService.Interface.ICrud;
using Domain.Entities;
using Infra.Data.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Application.Service.PedidoService
{
    public class PedidoAtualizar : IPedidoAtualizar
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAtualizacaoDoPedido _atualizacaoDoPedido;

        public PedidoAtualizar(AppDbContext appDbContext, IAtualizacaoDoPedido atualizacaoDoPedido)
        {
            _appDbContext = appDbContext;
            _atualizacaoDoPedido = atualizacaoDoPedido;
        }

        public async Task Atualizar(AtualizarPedido atualizarPedido)
        {
            var pedido = await _appDbContext.Pedidos.Include(x => x.Produtos).FirstOrDefaultAsync(x => x.Id == atualizarPedido.Id);

            if (pedido is null)
            {
                throw new Exception("Id não encontrado");
            }

            await _atualizacaoDoPedido.AtualizarProdutos(atualizarPedido, pedido);
            await Task.FromResult(_appDbContext.Set<Pedido>().Update(pedido));
            await _appDbContext.SaveChangesAsync();
        }
    }
}
