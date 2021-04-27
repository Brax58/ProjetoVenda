using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Entities
{
    public class PedidoProduto
    {
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }

        public PedidoProduto(Guid produtoId, Guid pedidoId)
        {
            ProdutoId = produtoId;
            PedidoId = pedidoId;
        }
    }
}
