using ProjetoVendas.Entities.Base;
using System.Collections.Generic;

namespace ProjetoVendas.Entities
{
    public class Produto : Entity
    {
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public int QuantidadeNoStoque { get; private set; }
        public bool Ativo { get; private set; }

        internal Produto(string descricao,decimal valor,int quantidadeNoStoque) {
            Descricao = descricao;
            Valor = valor;
            QuantidadeNoStoque = quantidadeNoStoque;
            Ativo = true;
        }

        internal void AddNewProduto(string descricao, decimal valor, int quantidadeNoStoque, bool ativo)
        {
            Descricao = descricao;
            Valor = valor;
            QuantidadeNoStoque = quantidadeNoStoque;
            SetAtivo(ativo);
        }

        internal void SetAtivo(bool ativo)
        {
            Ativo = ativo;
        }
    }
}
