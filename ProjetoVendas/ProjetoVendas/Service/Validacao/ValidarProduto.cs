using ProjetoVendas.Resquest.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service
{
    public class ValidarProduto
    {
        public bool ValidarCaracteristicaProduto(AdicionarProduto adicionarProduto)
        {

            if (adicionarProduto.Descricao.Length <= 200 && adicionarProduto.Valor >= 0 && adicionarProduto.QuantidadeNoStoque > 0)
                return true;
            else
                return false;

        }
    }
}
