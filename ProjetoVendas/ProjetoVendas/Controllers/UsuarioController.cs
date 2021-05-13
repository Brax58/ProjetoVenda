using Application.Request.Usuarios;
using Application.Service.UsuarioService.Interface.ICrud;
using Application.Service.UsuarioService.ValidacaoUsuarios;
using Infra.Data.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

using System.Threading.Tasks;

namespace Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        #region Injection

        private readonly ILogger<UsuarioController> _logger;
        private readonly AppDbContext _appDbContext;
        private readonly IUsuarioAdicionar _usuarioAdd;
        private readonly IUsuarioAtualizar _usuarioUpdate;
        private readonly IUsuarioObterPorId _usuarioGetId;
        private readonly IUsuarioObterTodos _usuarioGetTodos;
        private readonly IUsuarioRemover _usuarioDelete;
        private readonly ValidarUsuario _validarUsuario;

        public UsuarioController(ILogger<UsuarioController> logger, AppDbContext appDbContext,
            IUsuarioAdicionar usuarioAdicionar, IUsuarioAtualizar usuarioAtualizar,IUsuarioObterPorId usuarioObterPorId
            ,IUsuarioObterTodos usuarioObterTodos,IUsuarioRemover usuarioRemover,ValidarUsuario validarUsuario
            )
        {
            _appDbContext = appDbContext;
            _logger = logger;
            _usuarioAdd = usuarioAdicionar;
            _usuarioUpdate = usuarioAtualizar;
            _usuarioGetId = usuarioObterPorId;
            _usuarioGetTodos = usuarioObterTodos;
            _usuarioDelete = usuarioRemover;
            _validarUsuario = validarUsuario;
        }
        #endregion

        #region Add

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarUsuario adicionarUsuario)
        {
            // recebo a requisição e passo a responsabilidade de fazer a lógica de adicionar para outra classe (Princípio da Responsabilidade única (SOLID))
            // os metodos do controller não tem de ter muito código. basicamente uma linha que repassa a requisição pra outra classe fazer o cadastro
            // e outra linha que retorna a reposta para o frontend
                var validar = _validarUsuario.Validate(adicionarUsuario);

                if (!validar.IsValid) {
                    return BadRequest(validar.Errors);
                }

                Guid id = await _usuarioAdd.Adicionar(adicionarUsuario);
                return CreatedAtAction(nameof(Obter), id);
        }

        #endregion

        #region Update

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarUsuarios atualizarUsuario)
        {
            // recebo a requisição e passo a responsabilidade de fazer a lógica de adicionar para outra classe (Princípio da Responsabilidae única (SOLID))
            // os metodos do controller não tem de ter muito código. basicamente uma linha que repassa a requisição pra outra classe fazer a trativa
            // e outra linha que retorna a reposta para o frontend
            try { 
                atualizarUsuario.ObterId(id);
                await _usuarioUpdate.Atualizar(atualizarUsuario);
                return NoContent();

            } catch {
                return NotFound();
            }
        }
        #endregion

        #region Delete
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            // recebo a requisição e passo a responsabilidade de fazer a lógica de adicionar para outra classe (Princípio da Responsabilidae única (SOLID))
            // os metodos do controller não tem de ter muito código. basicamente uma linha que repassa a requisição pra outra classe fazer a trativa
            // e outra linha que retorna a reposta para o frontend

            try { 
                await _usuarioDelete.Remover(id);
                return NoContent();
            } 
            catch {
                return NotFound();
            }
        }

        #endregion

        #region GetTodos

        [HttpGet]
        public async Task<IActionResult> Obter()
        {
            // recebo a requisição e passo a responsabilidade de buscar todos usuários cadastrados para outra classe
            // metodos do controller não tem de ter lógica, basicamente uma linha que repassa a requisição pra outra classe fazer a trativa
            try
            {
                var usuarios = await _usuarioGetTodos.ObterTodos();
                return Ok(usuarios);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        #endregion

        #region GetId

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            // recebo a requisição e passo a responsabilidade de buscar o usuário cadastrado para outra classe
            // metodos do controller não tem de ter lógica, basicamente uma linha que repassa a requisição pra outra classe fazer a trativa
            try
            {
            var usuario = await _usuarioGetId.ObterPorId(id);
            return Ok(usuario);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        #endregion
    }
}
