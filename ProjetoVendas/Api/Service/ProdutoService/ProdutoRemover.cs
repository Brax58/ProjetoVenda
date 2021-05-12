using Application.Service.ProdutoService.Interface.ICrud;
using Domain.Entities;
using Infra.Data.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Application.Service.ProdutoService
{
    public class ProdutoRemover : IProdutoRemover
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoRemover(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Remover(Guid id)
        {
            try
            {
                var produto = await _appDbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);

                await Task.FromResult(_appDbContext.Set<Produto>().Remove(produto));

                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
