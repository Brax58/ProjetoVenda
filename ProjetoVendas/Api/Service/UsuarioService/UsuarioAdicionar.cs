using Application.Request.Usuarios;
using Application.Service.UsuarioService.Interface.ICrud;
using Domain.Entities;
using Infra.Data.Infra;
using System;
using System.Threading.Tasks;

namespace Application.Service.UsuarioService
{
    public class UsuarioAdicionar : IUsuarioAdicionar
    {

        private readonly AppDbContext _appDbContext;

        public UsuarioAdicionar(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Adicionar(AdicionarUsuario adicionarUsuario)
        {
            var usuario = new Usuario(adicionarUsuario.Nome, adicionarUsuario.Email, adicionarUsuario.Cpf, adicionarUsuario.DataDeNascimento);

            await _appDbContext.Usuarios.AddAsync(usuario);
            await _appDbContext.SaveChangesAsync();

            return usuario.Id;
        }
    }
}
