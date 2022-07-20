using FluentValidation;
using Produtos.Application.DTO;

namespace Produtos.Application.Validator
{
    public class ProdutoDTOIncluirValidator : AbstractValidator<ProdutoDTO>
    {
        public ProdutoDTOIncluirValidator()
        {
            RuleFor(p => p.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome do produto não pode ser nulo");

            RuleFor(p => p.Preco)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0).
                WithMessage("Informe um preço válido");
        }
    }
}