using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Resquest.Produto
{
    public class AdicionarProduto
    {
        //Descricao
        //Valor
        //QuantidadeNoStoque

        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int QuantidadeNoStoque { get; set; }
    }
}
