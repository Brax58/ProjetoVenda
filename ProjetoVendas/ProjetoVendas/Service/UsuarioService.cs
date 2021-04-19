using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Entities;
using ProjetoVendas.Infra;
using ProjetoVendas.Resquest.Usuario;
using ProjetoVendas.Service.AtualizacaoDasEntidades;
using ProjetoVendas.Service.Validacao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoVendas.Service
{
    public class UsuarioService
    {
        private readonly AppDbContext _appDbContext;

        public UsuarioService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Adicionar(AdicionarUsuario adicionarUsuario)
        {
            var validar = new ValidarUsuario();
            
            bool validarUsuario = validar.ValidarCaracteristicas(adicionarUsuario);

            if (!validarUsuario)
            {
                throw new Exception("Opa! Algo deu errado no momento de inserir o produto!");
            }

            var usuario = new Usuario(adicionarUsuario.Nome, adicionarUsuario.Email, adicionarUsuario.Cpf, adicionarUsuario.DataDeNascimento);

            await _appDbContext.Usuarios.AddAsync(usuario);
            await _appDbContext.SaveChangesAsync();

            return usuario.Id;
        }

        /*Se o usuário não for encontrado pelo ID(GUID) recebido, retornar 404 ou 204 para atualizado com sucesso.
       É importante validar todas as regras apresentadas no cadastro do usuário novamente para os campos que podem ser atualizados
       (por exemplo, campo nome deve conter no máximo 60 caracteres também na edição, e etc.).*/
        public async Task Atualizar(AtualizarUsuario atualizarUsuario)
        {
            try
            {
                var usuario = await _appDbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == atualizarUsuario.Id);
                _appDbContext.Entry(usuario).State = EntityState.Modified;

                var atualizarU = new AtualizacaoDoUsuario();
                atualizarU.AtualizarUsuario(usuario,atualizarUsuario);

                await Task.FromResult(_appDbContext.Set<Usuario>().Update(usuario));
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Ops! Algo deu errado no momento de atualizar o usuário: " + exception.Message);
            }
        }

        public async Task<List<Usuario>> ObterTodos()
        {
            try
            {
                return await _appDbContext.Usuarios.ToListAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Ops! Algo deu errado no momento de buscar o usuário: " + exception.Message);
            }
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
