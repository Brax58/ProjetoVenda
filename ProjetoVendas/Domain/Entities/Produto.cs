using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Produto : Entity
    {
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public int QuantidadeNoStoque { get; private set; }
        public bool Ativo { get; private set; }

        public Produto(string descricao,decimal valor,int quantidadeNoStoque) {
            Descricao = descricao;
            Valor = valor;
            QuantidadeNoStoque = quantidadeNoStoque;
            Ativo = true;
        }

        protected Produto()
        {

        }

        public void AddNewProduto(string descricao, decimal valor, int quantidadeNoStoque, bool ativo)
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
