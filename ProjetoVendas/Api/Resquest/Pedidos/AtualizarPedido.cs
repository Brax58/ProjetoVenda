using System;
using System.Collections.Generic;

namespace Application.Request.Pedidos
{
    public class AtualizarPedido
    {
        public Guid Id { get; set; }
        public List<Produtos> Produtos { get; set; }
        public void ObterId(Guid id)
        {
            Id = id;
        }
    }

    public class Produtos {
        public Guid Id { get; set; }
        public bool EhPraAdicionar { get; set; }
    }
}
