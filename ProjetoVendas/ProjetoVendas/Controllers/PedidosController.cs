using Application.Request.Pedidos;
using Application.Service.PedidoService.Interface.ICrud;
using Infra.Data.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : Controller
    {
        #region Injection

        private readonly ILogger<PedidosController> _logger;
        private readonly AppDbContext _Context;
        private readonly IPedidoAdicionar _pedidoAdd;
        private readonly IPedidoAtualizar _pedidoUpdate;
        private readonly IPedidoObterPorId _pedidoGetId;
        private readonly IPedidoObterTodos _pedidoGetTodos;
        private readonly IPedidoRemover _pedidoDelete;



        public PedidosController(ILogger<PedidosController> logger, AppDbContext appDbContext,
            IPedidoAdicionar pedidoAdicionar,IPedidoAtualizar pedidoAtualizar,IPedidoObterPorId pedidoObterPorId,
            IPedidoObterTodos pedidoObterTodos,IPedidoRemover pedidoRemover)
        {
            _Context = appDbContext;
            _logger = logger;
            _pedidoAdd = pedidoAdicionar;
            _pedidoUpdate = pedidoAtualizar;
            _pedidoGetId = pedidoObterPorId;
            _pedidoGetTodos = pedidoObterTodos;
            _pedidoDelete = pedidoRemover;
        }
        #endregion

        #region Add

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
                return BadRequest();
            }
        }

        #endregion

        #region Update

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id,[FromBody] AtualizarPedido atualizarPedido)
        {
            // recebo a requisição e passo a responsabilidade de fazer a lógica de adicionar para outra classe (Princípio da Responsabilidae única (SOLID))
            // os metodos do controller não tem de ter muito código. basicamente uma linha que repassa a requisição pra outra classe fazer a trativa
            // e outra linha que retorna a reposta para o frontend
            try
            {
                atualizarPedido.ObterId(id);
                await _pedidoUpdate.Atualizar(atualizarPedido);
                return NoContent();
            }
            catch (Exception obj)
            {
                return BadRequest(obj);
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
                await _pedidoDelete.Remover(id);
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
                var pedido = await _pedidoGetTodos.ObterTodos();
                return Ok(pedido);

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
                var pedido = await _pedidoGetId.ObterId(id);
                return Ok(pedido);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
        #endregion

    }
}
