using Application.Request.Usuarios;
using Domain.Entities;

namespace Application.Service.UsuarioService.Interface.IAtualizacaoDoUsuarios
{
    public interface IAtualizacaoDoUsuario
    {
        void AtualizarUsuario(Usuario usuario, AtualizarUsuarios atualizarUsuario);
    }
}
