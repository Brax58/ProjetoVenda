using ProjetoVendas.Resquest.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.Interfaces.Validar
{
    public interface IValidarProduto
    {
        bool ValidarCaracteristicaProduto(AdicionarProduto adicionarProduto);
    }
}
