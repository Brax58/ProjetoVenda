using ProjetoVendas.Entities;
using ProjetoVendas.Infra;
using ProjetoVendas.Resquest.Pedido;
using ProjetoVendas.Service.Interfaces.Crud.Pedidos.PedidoAdicionar;
using ProjetoVendas.Service.Interfaces.Validar;
using ProjetoVendas.Service.Interfaces.Validar.IValidarPedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.CrudEntidades.CrudPedido.PedidoAdicionar
{
    public class PedidoAdicionar : IPedidoAdicionar
    {
        private readonly IValidarPedido _validarPedido;
        private readonly AppDbContext _appDbContext;

        public PedidoAdicionar(IValidarPedido validarPedido, AppDbContext appDbContext)
        {
            _validarPedido = validarPedido;
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Adicionar(AdicionarPedido adicionarPedido)
        {

            bool validarPedido = _validarPedido.ValidarCaracteristicaPedido(adicionarPedido);

            if (!validarPedido)
            {
                throw new Exception("Opa! Algo deu errado no momento de inserir o pedido!");
            }
            var pedido = new Pedido(adicionarPedido.usuarioId, adicionarPedido.usuarioNome, adicionarPedido.usuarioCpf);
            await _appDbContext.Pedidos.AddAsync(pedido);
            await _appDbContext.SaveChangesAsync();

            return pedido.Id;

        }
    }
}
