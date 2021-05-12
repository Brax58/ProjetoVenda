using System;

namespace Application.Request.Pedidos
{
    public class AdicionarPedido
    {
        public Guid usuarioId { get; set; }
        public string usuarioCpf { get; set; }
        public string usuarioNome { get; set; }
    }
}
