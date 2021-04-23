using ProjetoVendas.Resquest.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.Interfaces.Crud.Usuarios.UsuarioAtualizar
{
    public interface IUsuarioAtualizar
    {
        Task Atualizar(AtualizarUsuario atualizarUsuario);
    }
}
