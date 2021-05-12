using Application.Request.Produtos;
using Application.Service.ProdutoService.Interface.IAtualizacaoDoProdutos;
using Application.Service.ProdutoService.Interface.ICrud;
using Domain.Entities;
using Infra.Data.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Application.Service.ProdutoService
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
