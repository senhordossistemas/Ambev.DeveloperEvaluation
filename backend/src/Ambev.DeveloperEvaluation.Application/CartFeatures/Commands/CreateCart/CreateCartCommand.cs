using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Dtos;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.CreateCart;

public sealed record CreateCartCommand(
    Guid UserId,
    IEnumerable<CartItemDto> Products
) : IRequest<CreateCartResult>;