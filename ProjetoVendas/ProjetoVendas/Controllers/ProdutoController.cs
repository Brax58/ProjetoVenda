using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjetoVendas.Entities;
using ProjetoVendas.Infra;
using ProjetoVendas.Resquest.Produto;
using ProjetoVendas.Service;

namespace ProjetoVendas.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly AppDbContext _Context;

        public ProdutoController(ILogger<ProdutoController> logger, AppDbContext appDbContext)
        {
            _Context = appDbContext;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarProduto adicionarProduto)
        {
            // recebo a requisição e passo a responsabilidade de fazer a lógica de adicionar para outra classe (Princípio da Responsabilidade única (SOLID))
            // os metodos do controller não tem de ter muito código. basicamente uma linha que repassa a requisição pra outra classe fazer o cadastro
            // e outra linha que retorna a reposta para o frontend            
            try {
            Guid id = await new ProdutoService(_Context).Adicionar(adicionarProduto);
            return CreatedAtAction(nameof(Obter), id);
            } 
            catch {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarProduto atualizarProduto)
        {
            // recebo a requisição e passo a responsabilidade de fazer a lógica de adicionar para outra classe (Princípio da Responsabilidae única (SOLID))
            // os metodos do controller não tem de ter muito código. basicamente uma linha que repassa a requisição pra outra classe fazer a trativa
            // e outra linha que retorna a reposta para o frontend
            try
            {
                atualizarProduto.ObterId(id);
                await new ProdutoService(_Context).Atualizar(atualizarProduto);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            // recebo a requisição e passo a responsabilidade de fazer a lógica de adicionar para outra classe (Princípio da Responsabilidae única (SOLID))
            // os metodos do controller não tem de ter muito código. basicamente uma linha que repassa a requisição pra outra classe fazer a trativa
            // e outra linha que retorna a reposta para o frontend
            try
            {
                await new ProdutoService(_Context).Remover(id);
                return NoContent();
            }
            catch (Exception) {
                return NotFound();
            }

        }

        [HttpGet]
        public async Task<IActionResult> Obter()
        {
            // recebo a requisição e passo a responsabilidade de buscar todos usuários cadastrados para outra classe
            // metodos do controller não tem de ter lógica, basicamente uma linha que repassa a requisição pra outra classe fazer a trativa
            try
            {
                var produtos = await new ProdutoService(_Context).ObterTodos();
                return Ok(produtos);

            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            // recebo a requisição e passo a responsabilidade de buscar o usuário cadastrado para outra classe
            // metodos do controller não tem de ter lógica, basicamente uma linha que repassa a requisição pra outra classe fazer a trativa
            try
            {
                var produto = await new ProdutoService(_Context).ObterPorId(id);
                return Ok(produto);
            }
            catch (Exception) {
                return NotFound();
            }

        }
    }
}
