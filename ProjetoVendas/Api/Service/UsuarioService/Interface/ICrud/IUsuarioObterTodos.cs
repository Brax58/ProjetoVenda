using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Service.UsuarioService.Interface.ICrud
{
    public interface IUsuarioObterTodos
    {
        Task<List<Usuario>> ObterTodos();
    }
}
