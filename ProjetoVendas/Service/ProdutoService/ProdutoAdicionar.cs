using ProjetoVendas.Entities;
using ProjetoVendas.Infra;
using ProjetoVendas.Resquest.Produto;
using ProjetoVendas.Service.Interfaces.Crud.Produtos;
using ProjetoVendas.Service.Interfaces.Validar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.CrudEntidades.CrudProduto.ProdutoAdicionar
{
    public class ProdutoAdicionar : IProdutoAdicionar
    {
        private readonly IValidarProduto _validarProduto;
        private readonly AppDbContext _appDbContext;

        public ProdutoAdicionar(IValidarProduto validarProduto, AppDbContext appDbContext)
        {
            _validarProduto = validarProduto;
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Adicionar(AdicionarProduto adicionarProduto)
        {

            bool validarProduto = _validarProduto.ValidarCaracteristicaProduto(adicionarProduto);

            if (!validarProduto)
            {
                throw new Exception("Opa! Algo deu errado no momento de inserir o produto!");
            }
            var produto = new Produto(adicionarProduto.Descricao, adicionarProduto.Valor, adicionarProduto.QuantidadeNoStoque);

            await _appDbContext.Produtos.AddAsync(produto);
            await _appDbContext.SaveChangesAsync();

            return produto.Id;

        }
    }
}
