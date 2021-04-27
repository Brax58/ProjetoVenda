using ProjetoVendas.Entities.Base;
using ProjetoVendas.Resquest.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Entities
{
    public class Pedido : Entity
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public Statuss Status { get; private set; }
        public Guid UsuarioId { get; set; }

        private readonly List<PedidoProduto> _pedidos = new List<PedidoProduto>();
        public IReadOnlyCollection<PedidoProduto> Pedidos => _pedidos;

        public Pedido(Guid usuarioId,string usuarioNome,string usuarioCpf)
        {
            Status = Statuss.aprovado;
            Nome = usuarioNome;
            Cpf = usuarioCpf;
            UsuarioId = usuarioId;
        }

        public void AddProduto(List<Produto> produtos) 
        {
            foreach (var produto in produtos)
            {
                _pedidos.Add(new PedidoProduto(produto.Id,Id));
            }
        }

        public enum Statuss
        {
            Cancelado,
            aprovado,
            Faturado,
        };
    }
}
