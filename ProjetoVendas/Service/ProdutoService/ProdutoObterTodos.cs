using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Entities;
using ProjetoVendas.Infra;
using ProjetoVendas.Service.Interfaces.Crud.Produtos.ProdutoObterTodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.CrudEntidades.CrudProduto.ProdutoObterTodos
{
    public class ProdutoObterTodos : IProdutoObterTodos
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoObterTodos(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Produto>> ObterTodos()
        {
            try
            {
                return await _appDbContext.Produtos.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
