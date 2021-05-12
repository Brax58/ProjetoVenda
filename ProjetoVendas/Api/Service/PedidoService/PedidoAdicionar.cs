using Application.Request.Pedidos;
using Application.Service.PedidoService.Interface.ICrud;
using Application.Service.PedidoService.Interface.IValidarPedidos;
using Domain.Entities;
using Infra.Data.Infra;
using System;
using System.Threading.Tasks;

namespace Application.Service.PedidoService
{
    public class PedidoAdicionar : IPedidoAdicionar
    {
        private readonly IValidarPedido _validarPedido;
        private readonly AppDbContext _appDbContext;

        public PedidoAdicionar(AppDbContext appDbContext,IValidarPedido validarPedido)
        {
            _validarPedido = validarPedido;
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Adicionar(AdicionarPedido adicionarPedido)
        {
            if (!_validarPedido.ValidarCaracteristicaPedido(adicionarPedido)) 
            {
                throw new Exception("Usuario não encontrado!.");
            }

            var pedido = new Pedido(adicionarPedido.usuarioId, adicionarPedido.usuarioNome, adicionarPedido.usuarioCpf);
            await _appDbContext.Pedidos.AddAsync(pedido);
            await _appDbContext.SaveChangesAsync();

            return pedido.Id;

        }
    }
}
