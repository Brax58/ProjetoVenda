using ProjetoVendas.Resquest.Produto;
using ProjetoVendas.Service.Interfaces.Validar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service
{
    public class ValidarProduto : IValidarProduto
    {
        public bool ValidarCaracteristicaProduto(AdicionarProduto adicionarProduto)
        {

            if (adicionarProduto.Descricao.Length <= 200 && adicionarProduto.Valor > 0 && adicionarProduto.QuantidadeNoStoque > 0)
                return true;
            else
                return false;

        }
    }
}
