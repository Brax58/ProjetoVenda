using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoVendas.Infra;
using ProjetoVendas.Resquest.Pedido;
using ProjetoVendas.Service.Interfaces.Crud.Pedidos.PedidoAdicionar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Controllers.PedidosController
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : Controller
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly AppDbContext _Context;
        private readonly IPedidoAdicionar _pedidoAdd;


        public PedidosController(ILogger<PedidosController> logger, AppDbContext appDbContext)
        {
            _Context = appDbContext;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarPedido adicionarPedido)
        {
            // recebo a requisição e passo a responsabilidade de fazer a lógica de adicionar para outra classe (Princípio da Responsabilidade única (SOLID))
            // os metodos do controller não tem de ter muito código. basicamente uma linha que repassa a requisição pra outra classe fazer o cadastro
            // e outra linha que retorna a reposta para o frontend.            
            try
            {
                Guid id = await _pedidoAdd.Adicionar(adicionarPedido);
                return CreatedAtAction(nameof(Obter), id);
            }
            catch
            {
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
                await _produtoUpdate.Atualizar(atualizarProduto);
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
                await _produtoDelete.Remover(id);
                return NoContent();
            }
            catch (Exception)
            {
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
                var produtos = await _produtoGetTodos.ObterTodos();
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
                var produto = await _produtoGetId.ObterId(id);
                return Ok(produto);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
    }
}
