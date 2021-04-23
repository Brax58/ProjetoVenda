using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Entities;
using ProjetoVendas.Infra;
using ProjetoVendas.Service.Interfaces.Crud.Usuarios.UsuarioObterPorId;
using System;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.CrudEntidades.CrudUsuario.UsuarioObterPorId
{
    public class UsuarioObterPorId : IUsuarioObterPorId
    {
        public readonly AppDbContext _appDbContext;
        public UsuarioObterPorId(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public async Task<Usuario> ObterPorId(Guid id)
        {
            try
            {
                return await _appDbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception exception)
            {
                throw new Exception("Ops! Algo deu errado no momento de buscar o usuário: " + exception.Message);
            }
        }
    }
}
