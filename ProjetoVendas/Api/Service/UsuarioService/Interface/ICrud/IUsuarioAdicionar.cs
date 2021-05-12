using Application.Request.Usuarios;
using System;
using System.Threading.Tasks;

namespace Application.Service.UsuarioService.Interface.ICrud
{
    public interface IUsuarioAdicionar
    {
        Task<Guid> Adicionar(AdicionarUsuario adicionarUsuario);
    }
}
