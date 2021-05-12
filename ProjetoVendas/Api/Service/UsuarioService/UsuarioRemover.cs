using Application.Service.UsuarioService.Interface.ICrud;
using Domain.Entities;
using Infra.Data.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Application.Service.UsuarioService
{
    public class UsuarioRemover : IUsuarioRemover
    {
        public readonly AppDbContext _appDbContext;
        public UsuarioRemover(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Remover(Guid id)
        {
            try
            {
                var usuario = await _appDbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

                await Task.FromResult(_appDbContext.Set<Usuario>().Remove(usuario));

                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Ops! Algo deu errado no momento de remover o usuário: " + exception.Message);
            }
        }
    }
}
