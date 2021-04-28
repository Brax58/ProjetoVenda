using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Entities;
using ProjetoVendas.Infra;
using ProjetoVendas.Resquest.Produto;
using ProjetoVendas.Service.Interfaces.Atualizar;
using ProjetoVendas.Service.Interfaces.Crud.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.CrudEntidades.CrudProduto.ProdutoAtualizar
{
    public class ProdutoAtualizar : IProdutoAtualizar
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAtualizacaoDoProduto _atualizacaoDoProduto;

        public ProdutoAtualizar(AppDbContext appDbContext, IAtualizacaoDoProduto atualizacaoDoProduto)
        {
            _appDbContext = appDbContext;
            _atualizacaoDoProduto = atualizacaoDoProduto;
        }

        public async Task Atualizar(AtualizarProduto atualizarProduto)
        {
            try
            {
                var produto = await _appDbContext.Produtos.FirstOrDefaultAsync(x => x.Id == atualizarProduto.Id);
                _appDbContext.Entry(produto).State = EntityState.Modified;

                _atualizacaoDoProduto.AtualizarProduto(produto, atualizarProduto);

                await Task.FromResult(_appDbContext.Set<Produto>().Update(produto));
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Ops! Algo deu errado no momento de atualizar o produto: " + exception.Message);
            }
        }
    }
}
