using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.Interfaces.Crud.Usuarios.UsuarioRemover
{
    public interface IUsuarioRemover
    {
        Task Remover(Guid id);
    }
}
