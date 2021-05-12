using System;

namespace Domain.Entities
{
    public class PedidoProduto
    {
        
        public Guid Id { get; private set; }
        public Guid ProdutoId { get; private set; }
        public Guid PedidoId { get; private set; }
        public Pedido Pedido { get; set; }
        
        public PedidoProduto()
        {
                
        }
        
        public PedidoProduto(Guid produtoId, Guid pedidoId)
        {
            Id = Guid.NewGuid();
            ProdutoId = produtoId;
            PedidoId = pedidoId;
        }
    }
}
