using Application.Request.Pedidos;
using Application.Service.PedidoService.Interface.IValidarPedidos;
using FluentValidation;
using Infra.Data.Infra;
using System.Linq;

namespace Application.Service.PedidoService.ValidacaoPedidos
{
    public class ValidarPedido : IValidarPedido
    {
        private readonly AppDbContext _appDbContext;

        public ValidarPedido(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool ValidarCaracteristicaPedido(AdicionarPedido adicionarPedido)
        {
            var validar = _appDbContext.Usuarios.FirstOrDefault(x => x.Id == adicionarPedido.usuarioId);
            
            if (validar is null)
                return false;

            if (validar.Nome == adicionarPedido.usuarioNome && validar.Cpf == adicionarPedido.usuarioCpf)
                return true;
            else
                return false;
        }

    }
}
