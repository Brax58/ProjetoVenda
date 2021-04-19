using ProjetoVendas.Resquest.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.Validacao
{
    public class ValidarUsuario
    {
        public bool ValidarCaracteristicas(AdicionarUsuario adicionarUsuario)
        {
            if (adicionarUsuario.Nome.Length <= 60 && adicionarUsuario.Nome.Length > 0
                && adicionarUsuario.Email.Length > 0 && adicionarUsuario.Email.Contains("@")
                && adicionarUsuario.Email.Contains(".com") && adicionarUsuario.DataDeNascimento.Length > 0
                && adicionarUsuario.DataDeNascimento.Contains("/") && adicionarUsuario.Cpf.Length > 0
                && !adicionarUsuario.Cpf.Contains(".") && !adicionarUsuario.Cpf.Contains("-"))
                return true;
            else
                return false;
        }
    }
}
