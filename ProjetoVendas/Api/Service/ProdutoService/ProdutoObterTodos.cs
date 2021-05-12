using Application.Request.Pedidos;
using Application.Service.ProdutoService.Interface.ICrud;
using Domain.Entities;
using Infra.Data.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Service.ProdutoService
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
