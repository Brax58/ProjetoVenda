using ProjetoVendas.Entities.Base;
using System;

namespace ProjetoVendas.Entities
{
    public class Produto : Entity
    {
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public int QuantidadeNoStoque { get; private set; }

        internal Produto(string descricao,decimal valor,int quantidadeNoStoque) {
            Descricao = descricao;
            Valor = valor;
            QuantidadeNoStoque = quantidadeNoStoque;
        }
    }
}
