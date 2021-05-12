using Application.Request.Usuarios;
using Application.Service.UsuarioService.Interface.IAtualizacaoDoUsuarios;
using Domain.Entities;

namespace Application.Service.UsuarioService.AtualizacaoDoUsuario
{
    public class AtualizacaoDoUsuario : IAtualizacaoDoUsuario
    {
        public void AtualizarUsuario(Usuario usuario, AtualizarUsuarios atualizarUsuario)
        {
            usuario.AddNewUsuario(atualizarUsuario.Nome, atualizarUsuario.Ativo);
        }
    }
}
