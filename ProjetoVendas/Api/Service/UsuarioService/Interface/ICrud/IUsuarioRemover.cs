using System;
using System.Threading.Tasks;

namespace Application.Service.UsuarioService.Interface.ICrud
{
    public interface IUsuarioRemover
    {
        Task Remover(Guid id);
    }
}
