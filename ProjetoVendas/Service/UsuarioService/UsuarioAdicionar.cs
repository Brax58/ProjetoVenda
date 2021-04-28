using ProjetoVendas.Entities;
using ProjetoVendas.Infra;
using ProjetoVendas.Resquest.Usuarios;
using ProjetoVendas.Service.Interfaces.Crud.Usuarios.UsuarioAdicionar;
using ProjetoVendas.Service.Interfaces.Validar;
using System;
using System.Threading.Tasks;

namespace ProjetoVendas.Service.CrudEntidades.CrudUsuario.UsuarioAdicionar
{
    public class UsuarioAdicionar : IUsuarioAdicionar
    {

        private readonly AppDbContext _appDbContext;
        private readonly IValidarUsuario _validarUsuario;

        public UsuarioAdicionar(AppDbContext appDbContext, IValidarUsuario validarUsuario)
        {
            _appDbContext = appDbContext;
            _validarUsuario = validarUsuario;
        }

        public async Task<Guid> Adicionar(AdicionarUsuario adicionarUsuario)
        {
            bool validarUsuario = _validarUsuario.ValidarCaracteristicas(adicionarUsuario);

            if (!validarUsuario)
            {
                throw new Exception("Opa! Algo deu errado no momento de inserir o produto!");
            }

            var usuario = new Usuario(adicionarUsuario.Nome, adicionarUsuario.Email, adicionarUsuario.Cpf, adicionarUsuario.DataDeNascimento);

            await _appDbContext.Usuarios.AddAsync(usuario);
            await _appDbContext.SaveChangesAsync();

            return usuario.Id;
        }
    }
}
