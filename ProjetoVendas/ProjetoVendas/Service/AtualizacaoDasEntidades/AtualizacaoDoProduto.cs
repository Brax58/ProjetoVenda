using ProjetoVendas.Entities;
using ProjetoVendas.Resquest.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.AtualizacaoDasEntidades
{
    public class AtualizacaoDoProduto
    {
        public void AtualizarProduto(Produto produto, AtualizarProduto atualizarProduto)
        {
            produto.AddNewProduto(atualizarProduto.Descricao, atualizarProduto.Valor, atualizarProduto.QuantidadeNoEstoque);
        }
    }
}
