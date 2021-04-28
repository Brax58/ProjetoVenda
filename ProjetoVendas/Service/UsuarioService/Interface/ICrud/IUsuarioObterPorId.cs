using ProjetoVendas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.Interfaces.Crud.Usuarios.UsuarioObterPorId
{
    public interface IUsuarioObterPorId
    {
        Task<Usuario> ObterPorId(Guid id);
    }
}
