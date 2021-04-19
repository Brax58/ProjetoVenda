using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoVendas.Infra;
using ProjetoVendas.Resquest.Usuario;
using ProjetoVendas.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly AppDbContext _appDbContext;

        public UsuarioController(ILogger<UsuarioController> logger, AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarUsuario adicionarUsuario)
        {
            // recebo a requisição e passo a responsabilidade de fazer a lógica de adicionar para outra classe (Princípio da Responsabilidade única (SOLID))
            // os metodos do controller não tem de ter muito código. basicamente uma linha que repassa a requisição pra outra classe fazer o cadastro
            // e outra linha que retorna a reposta para o frontend
            Guid id = await new UsuarioService(_appDbContext).Adicionar(adicionarUsuario);

            return CreatedAtAction(nameof(Obter), id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarUsuario atualizarUsuario)
        {
            // recebo a requisição e passo a responsabilidade de fazer a lógica de adicionar para outra classe (Princípio da Responsabilidae única (SOLID))
            // os metodos do controller não tem de ter muito código. basicamente uma linha que repassa a requisição pra outra classe fazer a trativa
            // e outra linha que retorna a reposta para o frontend
            atualizarUsuario.Id = id;
            await new UsuarioService(_appDbContext).Atualizar(atualizarUsuario);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            // recebo a requisição e passo a responsabilidade de fazer a lógica de adicionar para outra classe (Princípio da Responsabilidae única (SOLID))
            // os metodos do controller não tem de ter muito código. basicamente uma linha que repassa a requisição pra outra classe fazer a trativa
            // e outra linha que retorna a reposta para o frontend
            await new UsuarioService(_appDbContext).Remover(id);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obter()
        {
            // recebo a requisição e passo a responsabilidade de buscar todos usuários cadastrados para outra classe
            // metodos do controller não tem de ter lógica, basicamente uma linha que repassa a requisição pra outra classe fazer a trativa
            var usuarios = await new UsuarioService(_appDbContext).ObterTodos();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            // recebo a requisição e passo a responsabilidade de buscar o usuário cadastrado para outra classe
            // metodos do controller não tem de ter lógica, basicamente uma linha que repassa a requisição pra outra classe fazer a trativa
            var usuario = await new UsuarioService(_appDbContext).ObterPorId(id);

            return Ok(usuario);
        }
    }
}
