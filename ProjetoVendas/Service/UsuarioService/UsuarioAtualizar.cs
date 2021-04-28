using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Entities;
using ProjetoVendas.Infra;
using ProjetoVendas.Resquest.Usuarios;
using ProjetoVendas.Service.AtualizacaoDasEntidades;
using ProjetoVendas.Service.Interfaces.Atualizar;
using ProjetoVendas.Service.Interfaces.Crud.Usuarios.UsuarioAtualizar;
using System;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.CrudEntidades.CrudUsuario.UsuarioAtualizar
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
