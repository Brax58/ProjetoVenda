using ProjetoVendas.Entities;
using ProjetoVendas.Resquest.Produto;


namespace ProjetoVendas.Service.Interfaces.Atualizar
{
    public interface IAtualizacaoDoProduto
    {
        void AtualizarProduto(Produto produto, AtualizarProduto atualizarProduto);
    }
}
        