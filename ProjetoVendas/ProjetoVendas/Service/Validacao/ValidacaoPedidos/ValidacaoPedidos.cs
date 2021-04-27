using ProjetoVendas.Resquest.Pedido;
using ProjetoVendas.Service.Interfaces.Validar.IValidarPedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.Validacao.ValidacaoPedidos
{
    public class ValidarPedido : IValidarPedido
    {
        public bool ValidarCaracteristicaPedido(AdicionarPedido adicionarPedido)
        {

            if (adicionarPedido.usuario.Nome.Length > 0 && adicionarPedido.usuario.Nome.Length <= 60 &&
                adicionarPedido.usuario.Cpf.Length == 11 && !adicionarPedido.usuario.Cpf.Contains(".") && !adicionarPedido.usuario.Cpf.Contains("-"))
                return true;
            else
                return false;

        }
    }
}
