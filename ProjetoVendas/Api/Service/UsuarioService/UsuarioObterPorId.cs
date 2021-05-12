using Application.Service.UsuarioService.Interface.ICrud;
using Domain.Entities;
using Infra.Data.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Application.Service.UsuarioService
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
