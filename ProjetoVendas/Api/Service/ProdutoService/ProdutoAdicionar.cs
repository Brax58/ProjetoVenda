using Application.Request.Produtos;
using Application.Service.ProdutoService.Interface.ICrud;
using Application.Service.ProdutoService.ValidacaoProdutos;
using Domain.Entities;
using Infra.Data.Infra;
using System;
using System.Threading.Tasks;

namespace Application.Service.ProdutoService
{
    public class ProdutoAdicionar : IProdutoAdicionar
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoAdicionar(ValidarProduto validationRules,AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Adicionar(AdicionarProduto adicionarProduto)
        {
            var produto = new Produto(adicionarProduto.Descricao, adicionarProduto.Valor, adicionarProduto.QuantidadeNoStoque);

            await _appDbContext.Produtos.AddAsync(produto);
            await _appDbContext.SaveChangesAsync();

            return produto.Id;

        }
    }
}
