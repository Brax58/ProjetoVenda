using Application.Request.Pedidos;
using Application.Service.ProdutoService.Interface.ICrud;
using Domain.Entities;
using Infra.Data.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Application.Service.ProdutoService
{
    public class ProdutoObterPorId : IProdutoObterPorId
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoObterPorId(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Produto> ObterId(Guid id)
        {
            try
            {
                return await _appDbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
