using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Entities;
using ProjetoVendas.Infra;
using ProjetoVendas.Service.Interfaces.Crud.Produtos.ProdutoRemover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.CrudEntidades.CrudProduto.ProdutoRemover
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
