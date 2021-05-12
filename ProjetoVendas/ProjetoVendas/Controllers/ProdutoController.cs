using System;
using System.Threading.Tasks;
using Application.Request.Produtos;
using Application.Service.ProdutoService.Interface.ICrud;
using Application.Service.ProdutoService.ValidacaoProdutos;
using Infra.Data.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        #region Injection

        private readonly ILogger<ProdutoController> _logger;
        private readonly AppDbContext _Context;
        private readonly IProdutoAdicionar _produtoAdd;
        private readonly IProdutoAtualizar _produtoUpdate;
        private readonly IProdutoObterPorId _produtoGetId;
        private readonly IProdutoObterTodos _produtoGetTodos;
        private readonly IProdutoRemover _produtoDelete;
        private ValidarProduto _validacao;

        public ProdutoController(ILogger<ProdutoController> logger, AppDbContext appDbContext,
            IProdutoAdicionar produtoAdicionar, IProdutoAtualizar produtoAtualizar, IProdutoObterPorId produtoObterPorId,
            IProdutoObterTodos produtoObterTodos, IProdutoRemover produtoRemover, ValidarProduto validationRules
            )
        {
            _Context = appDbContext;
            _logger = logger;
            _produtoAdd = produtoAdicionar;
            _produtoUpdate = produtoAtualizar;
            _produtoGetId = produtoObterPorId;
            _produtoGetTodos = produtoObterTodos;
            _produtoDelete = produtoRemover;
            _validacao = validationRules;

        }
        #endregion

        #region Add
        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarProduto adicionarProduto)
        {
            // recebo a requisição e passo a responsabilidade de fazer a lógica de adicionar para outra classe (Princípio da Responsabilidade única (SOLID))
            // os metodos do controller não tem de ter muito código. basicamente uma linha que repassa a requisição pra outra classe fazer o cadastro
            // e outra linha que retorna a reposta para o frontend            

            var validate = _validacao.Validate(adicionarProduto);
            if (!validate.IsValid)
            {
                return BadRequest(validate.Errors);
            }

            Guid id = await _produtoAdd.Adicionar(adicionarProduto);
            return CreatedAtAction(nameof(Obter), id);
        }

        #endregion

        #region Update

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarProduto atualizarProduto)
        {
            // recebo a requisição e passo a responsabilidade de fazer a lógica de adicionar para outra classe (Princípio da Responsabilidae única (SOLID))
            // os metodos do controller não tem de ter muito código. basicamente uma linha que repassa a requisição pra outra classe fazer a trativa
            // e outra linha que retorna a reposta para o frontend
            try
            {
                atualizarProduto.ObterId(id);
                await _produtoUpdate.Atualizar(atualizarProduto);
                return NoContent();
            }
            catch (Exception)
            {
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
            try
            {
                await _produtoDelete.Remover(id);
                return NoContent();
            }
            catch (Exception)
            {
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
                var produtos = await _produtoGetTodos.ObterTodos();
                return Ok(produtos);

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
                var produto = await _produtoGetId.ObterId(id);
                return Ok(produto);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
        #endregion
    }
}
