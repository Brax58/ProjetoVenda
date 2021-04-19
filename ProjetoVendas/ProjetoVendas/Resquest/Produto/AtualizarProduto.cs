using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Resquest.Produto
{
    public class AtualizarProduto
    {
        public Guid Id{ get; set; }
        public string Descricao { get; set; }
        public Decimal Valor { get; set; }
        public bool Ativo { get; set; }
        public int QuantidadeNoEstoque{ get; set; }
        public DateTime DataDeCadastro { get; set; }
    }
}
