using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate;
using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.UpdateCart;

public class UpdateCartCommandHandler(
    ICartRepository cartRepository,
    IMapper mapper)
    : IRequestHandler<AddOrUpdateCartItemCommand, UpdateCartResult>
{
    public async Task<UpdateCartResult> Handle(AddOrUpdateCartItemCommand command, CancellationToken cancellationToken)
    {
        var validator = new AddOrUpdateCartItemCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = await cartRepository.GetByUserIdAsync(command.UserId, cancellationToken) ?? new Cart(command.UserId);

        cart.AddProduct(command.ProductId, command.Quantity);
        
        cart.UpdateDate();

        if (cart.Id == Guid.Empty)
            await cartRepository.CreateAsync(cart, cancellationToken);
        else
            await cartRepository.UpdateAsync(cart, cancellationToken);
        
        return mapper.Map<UpdateCartResult>(cart);
    }
}