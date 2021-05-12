using Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Pedido : Entity
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public Statuss Status { get; private set; }
        public Guid UsuarioId { get; set; }

        private List<PedidoProduto> _produtos = new List<PedidoProduto>();
        public IReadOnlyCollection<PedidoProduto> Produtos => _produtos;

        public Pedido(Guid usuarioId,string usuarioNome,string usuarioCpf)
        {
            Status = Statuss.aprovado;
            Nome = usuarioNome;
            Cpf = usuarioCpf;
            UsuarioId = usuarioId;
        }

        protected Pedido()
        {

        }

        public void AdicionarProduto(Produto produto)
        {
           _produtos.Add(new PedidoProduto(produto.Id, Id));
        }

        public void RemoverProduto(Guid id) 
        {
            _produtos.Remove(_produtos.Find(x => x.ProdutoId == id));
        }

        public enum Statuss
        {
            Cancelado,
            aprovado,
            Faturado,
        };
    }
}
