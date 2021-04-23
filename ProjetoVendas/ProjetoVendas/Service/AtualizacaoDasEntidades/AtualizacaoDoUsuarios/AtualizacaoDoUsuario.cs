using ProjetoVendas.Entities;
using ProjetoVendas.Resquest.Usuario;
using ProjetoVendas.Service.Interfaces.Atualizar;

namespace ProjetoVendas.Service.AtualizacaoDasEntidades
{
    public class AtualizacaoDoUsuario : IAtualizacaoDoUsuario
    {
        public void AtualizarUsuario(Usuario usuario, AtualizarUsuario atualizarUsuario)
        {
            usuario.AddNewUsuario(atualizarUsuario.Nome, atualizarUsuario.Ativo);
        }
    }
}
