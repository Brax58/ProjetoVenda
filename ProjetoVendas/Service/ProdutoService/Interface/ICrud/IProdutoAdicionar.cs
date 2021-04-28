using ProjetoVendas.Resquest.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.Interfaces.Crud.Produtos
{
    public interface IProdutoAdicionar
    {
        Task<Guid> Adicionar(AdicionarProduto adicionarProduto);
    }
}
