﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.Interfaces.Crud.Produtos.ProdutoRemover
{
    public interface IProdutoRemover
    {
        Task Remover(Guid id);
    }
}