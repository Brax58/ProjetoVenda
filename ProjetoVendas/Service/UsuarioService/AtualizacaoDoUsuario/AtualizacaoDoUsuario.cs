using ProjetoVendas.Entities;
using ProjetoVendas.Resquest.Usuarios;
using ProjetoVendas.Service.Interfaces.Atualizar;

namespace ProjetoVendas.Service.AtualizacaoDasEntidades
{
    public class AtualizacaoDoUsuario : IAtualizacaoDoUsuario
    {
        public void AtualizarUsuario(Usuario usuario, AtualizarUsuarios atualizarUsuario)
        {
            usuario.AddNewUsuario(atualizarUsuario.Nome, atualizarUsuario.Ativo);
        }
    }
}
