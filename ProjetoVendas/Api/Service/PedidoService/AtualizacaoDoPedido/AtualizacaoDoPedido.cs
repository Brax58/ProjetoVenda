using Application.Request.Pedidos;
using Application.Service.PedidoService.Interface.IAtualizacaoDoPedido;
using Domain.Entities;
using Infra.Data.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Service.PedidoService.AtualizacaoDoPedido
{
    public class AtualizacaoDoPedido : IAtualizacaoDoPedido
    {
        private readonly AppDbContext _appDbContext;

        public AtualizacaoDoPedido(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task AtualizarProdutos(AtualizarPedido atualizarPedido, Pedido pedido)
        {
            foreach (var produto in atualizarPedido.Produtos)
            {
                if (produto.EhPraAdicionar)
                    await AdicionarProduto(pedido, produto.Id);
                else
                    RemoverProduto(pedido, produto.Id);
            }
        }

        private async Task AdicionarProduto(Pedido pedido, Guid id)
        {

            if (!pedido.Produtos.Any(x => x.ProdutoId == id))
            {
                var produto = await _appDbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);

                if (produto != null)
                    pedido.AdicionarProduto(produto);

            }
        }

        private void RemoverProduto(Pedido pedido, Guid id)
        {
            pedido.RemoverProduto(id);
        }
    }
}
