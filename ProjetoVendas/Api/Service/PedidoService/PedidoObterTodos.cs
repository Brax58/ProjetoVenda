using Application.Service.PedidoService.Interface.ICrud;
using Domain.Entities;
using Infra.Data.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Service.PedidoService
{
    public class PedidoObterTodos : IPedidoObterTodos
    {
        private readonly AppDbContext _appDbContext;

        public PedidoObterTodos(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Pedido>> ObterTodos()
        {
            try
            {
                return await _appDbContext.Pedidos.Include(x => x.Produtos).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
