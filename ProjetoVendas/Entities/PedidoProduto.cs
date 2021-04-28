using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Entities
{
    public class PedidoProduto
    {
        
        public Guid Id { get; private set; }
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }

        public PedidoProduto(Guid produtoId, Guid pedidoId)
        {
            Id = Guid.NewGuid();
            ProdutoId = produtoId;
            PedidoId = pedidoId;
        }
    }
}
