using ProjetoVendas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.Interfaces.Crud.Produtos
{
    public interface IProdutoObterPorId
    {
        Task<Produto> ObterId(Guid id);
    }
}
