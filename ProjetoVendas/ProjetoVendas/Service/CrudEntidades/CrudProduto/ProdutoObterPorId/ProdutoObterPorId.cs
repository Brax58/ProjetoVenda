using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Entities;
using ProjetoVendas.Infra;
using ProjetoVendas.Service.Interfaces.Crud.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.CrudEntidades.CrudProduto.ProdutoObterPorId
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
