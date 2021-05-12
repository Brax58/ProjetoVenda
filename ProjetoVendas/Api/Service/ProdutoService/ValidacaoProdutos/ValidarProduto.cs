using Application.Request.Produtos;
using FluentValidation;

namespace Application.Service.ProdutoService.ValidacaoProdutos
{
    public class ValidarProduto : AbstractValidator<AdicionarProduto>
    {
        public ValidarProduto()
        {
            RuleFor(X => X.Descricao).Length(1, 200).WithMessage("A descrição exedeu o limite permitido de 200 caracteres!.");
            RuleFor(X => X.QuantidadeNoStoque).NotEqual(0).WithMessage("Quantidade no estoque tem que ser maior que 0!.");
            RuleFor(X => X.Valor).NotEqual(0).WithMessage("Valor tem que ser maior que 0!.");
        }
    }
}
