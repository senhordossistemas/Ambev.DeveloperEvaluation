using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate;
using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.CreateCart;

public class CreateCartCommandHandler(ICartRepository cartRepository, IMapper mapper)
    : IRequestHandler<CreateCartCommand, CreateCartResult>
{
    public async Task<CreateCartResult> Handle(CreateCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCartCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = mapper.Map<Cart>(command);

        var createdCart = await cartRepository.CreateAsync(cart, cancellationToken);
        var result = mapper.Map<CreateCartResult>(createdCart);
        return result;
    }
}