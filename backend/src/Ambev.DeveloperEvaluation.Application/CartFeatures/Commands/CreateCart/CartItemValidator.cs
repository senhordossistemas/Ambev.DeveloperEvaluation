using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Dtos;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.CreateCart;

public class CartItemValidator : AbstractValidator<CartItemDto>
{
    public CartItemValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("Product ID is required");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero");
    }
}