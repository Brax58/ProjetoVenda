using ProjetoVendas.Resquest.Usuario;
using ProjetoVendas.Service.Interfaces.Validar;

namespace ProjetoVendas.Service.Validacao
{
    public class ValidarUsuario : IValidarUsuario
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
