using ProjetoVendas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.Interfaces.Crud.Produtos.ProdutoObterTodos
{
    public interface IProdutoObterTodos
    {
        Task<List<Produto>> ObterTodos();
    }
}
