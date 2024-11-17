using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.DeleteCart;

public class DeleteCartCommandHandler(ICartRepository cartRepository) : IRequestHandler<DeleteCartCommand, bool>
{
    public async Task<bool> Handle(DeleteCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new DeleteCartValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = await cartRepository.GetByIdAsync(command.Id, cancellationToken)
                   ?? throw new KeyNotFoundException($"Cart with ID {command.Id} not found.");

        var deletedCart = await cartRepository.DeleteAsync(cart.Id, cancellationToken);
        if (!deletedCart) throw new Exception($"Cart with Id {command.Id} not deleted.");
        
        return true;
    }
}