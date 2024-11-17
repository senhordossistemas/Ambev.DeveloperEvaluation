using Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.CreateCart;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
{
    public CreateCartRequestValidator()
    {
        RuleFor(sale => sale.UserId).NotEmpty().NotNull();
        RuleFor(x => x.Products)
            .NotEmpty().WithMessage("Products cannot be empty")
            .Must(items => items != null && items.Any()).WithMessage("Cart must contain at least one item")
            .ForEach(item => item.SetValidator(new CartItemValidator()));
    }
}