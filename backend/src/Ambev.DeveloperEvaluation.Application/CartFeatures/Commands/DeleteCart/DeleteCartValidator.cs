using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.DeleteCart;

public class DeleteCartValidator : AbstractValidator<DeleteCartCommand>
{
    /// <summary>
    ///     Initializes validation rules for DeleteCartCommand
    /// </summary>
    public DeleteCartValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Cart ID is required");
    }
}