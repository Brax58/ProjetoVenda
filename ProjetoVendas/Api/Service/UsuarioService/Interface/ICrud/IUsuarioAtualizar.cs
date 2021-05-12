using Application.Request.Usuarios;
using System.Threading.Tasks;

namespace Application.Service.UsuarioService.Interface.ICrud
{
    public interface IUsuarioAtualizar
    {
        Task Atualizar(AtualizarUsuarios atualizarUsuario);
    }
}
