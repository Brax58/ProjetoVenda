using ProjetoVendas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Resquest.Pedido
{
    public class AdicionarPedido
    {
        public Guid usuarioId { get; set; }
        public string usuarioCpf { get; set; }
        public string usuarioNome { get; set; }
    }
}
