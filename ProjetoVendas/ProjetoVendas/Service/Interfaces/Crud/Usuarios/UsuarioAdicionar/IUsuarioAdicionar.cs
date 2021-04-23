using ProjetoVendas.Resquest.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.Interfaces.Crud.Usuarios.UsuarioAdicionar
{
    public interface IUsuarioAdicionar
    {
        Task<Guid> Adicionar(AdicionarUsuario adicionarUsuario);
    }
}
