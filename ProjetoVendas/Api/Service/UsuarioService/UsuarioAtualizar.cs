using Application.Request.Usuarios;
using Application.Service.UsuarioService.Interface.IAtualizacaoDoUsuarios;
using Application.Service.UsuarioService.Interface.ICrud;
using Domain.Entities;
using Infra.Data.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Application.Service.UsuarioService
{
    public class UsuarioAtualizar : IUsuarioAtualizar
    {

        private readonly AppDbContext _appDbContext;
        private readonly IAtualizacaoDoUsuario _atualizacaoDoUsuario;

        public UsuarioAtualizar(AppDbContext appDbContext, IAtualizacaoDoUsuario atualizacaoDoUsuario)
        {
            _appDbContext = appDbContext;
            _atualizacaoDoUsuario = atualizacaoDoUsuario;
        }

        public async Task Atualizar(AtualizarUsuarios atualizarUsuario)
        {
            try
            {
                var usuario = await _appDbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == atualizarUsuario.Id);
                _appDbContext.Entry(usuario).State = EntityState.Modified;


                _atualizacaoDoUsuario.AtualizarUsuario(usuario, atualizarUsuario);

                await Task.FromResult(_appDbContext.Set<Usuario>().Update(usuario));
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
