using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Entities;
using ProjetoVendas.Infra;
using ProjetoVendas.Resquest.Produto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoVendas.Service
{
    [ApiController]
    public class ProdutoService
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Adicionar(AdicionarProduto adicionarProduto)
        {
            try
            {
                var produto = new Produto(adicionarProduto.Descricao,adicionarProduto.Valor,adicionarProduto.QuantidadeNoStoque);

                await _appDbContext.Produtos.AddAsync(produto);
                await _appDbContext.SaveChangesAsync();

                return produto.Id;
            }
            catch (Exception exception)
            {
                throw new Exception("Opa! Algo deu errado no momento de inserir o produto: " + exception.Message);
            }
        }

        public async Task Atualizar(AtualizarProduto atualizarProduto)
        {
            try
            {
                var produto = await _appDbContext.Produtos.FirstOrDefaultAsync(x => x.Id == atualizarProduto.Id);
                _appDbContext.Entry(produto).State = EntityState.Modified;
                await Task.FromResult(_appDbContext.Set<Produto>().Update(produto));

                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Ops! Algo deu errado no momento de atualizar o produto: " + exception.Message);
            }
        }

        public async Task<List<Produto>> ObterTodos()
        {
            try
            {
                return await _appDbContext.Produtos.ToListAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Ops! Algo deu errado no momento de buscar os Produtos: " + exception.Message);
            }
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            try
            {
                return await _appDbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception exception)
            {
                throw new Exception("Ops! Algo deu errado no momento de buscar o Produto solicitado: " + exception.Message);
            }
        }

        public async Task Remover(Guid id)
        {
            try
            {
                var produto = await _appDbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);

                await Task.FromResult(_appDbContext.Set<Produto>().Remove(produto));

                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Ops! Algo deu errado no momento de excluir o produto: " + exception.Message);
            }
        }
    }
}
