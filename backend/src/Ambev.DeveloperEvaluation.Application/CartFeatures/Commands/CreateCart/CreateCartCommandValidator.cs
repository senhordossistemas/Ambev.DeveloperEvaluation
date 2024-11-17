using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.CreateCart;

public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
    public CreateCartCommandValidator()
    {
        RuleFor(sale => sale.UserId).NotEmpty().NotNull();
        RuleFor(x => x.Products)
            .NotEmpty().WithMessage("Products cannot be empty")
            .Must(items => items != null && items.Any()).WithMessage("Cart must contain at least one item")
            .ForEach(item => item.SetValidator(new CartItemValidator()));
    }
}