using ProjetoVendas.Entities;
using ProjetoVendas.Resquest.Usuario;

namespace ProjetoVendas.Service.AtualizacaoDasEntidades
{
    public class AtualizacaoDoUsuario
    {
        public void AtualizarUsuario(Usuario usuario, AtualizarUsuario atualizarUsuario)
        {
            usuario.AddNewUsuario(atualizarUsuario.Nome, atualizarUsuario.Ativo);
        }
    }
}
