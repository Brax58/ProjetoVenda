using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Service.UsuarioService.Interface.ICrud
{
    public interface IUsuarioObterPorId
    {
        Task<Usuario> ObterPorId(Guid id);
    }
}
