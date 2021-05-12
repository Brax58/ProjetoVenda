using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Request.Produtos
{
    public class AtualizarProduto
    {
        public Guid Id{ get; private set; }
        public string Descricao { get; set; }
        public Decimal Valor { get; set; }
        public bool Ativo { get; set; }
        public int QuantidadeNoEstoque{ get; set; }
        public DateTime DataDeCadastro { get; set; }

        public void ObterId(Guid id) {
            Id = id;
        }
    }
}
