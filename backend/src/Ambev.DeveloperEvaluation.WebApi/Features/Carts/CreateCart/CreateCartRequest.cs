using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Dtos;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public sealed record CreateCartRequest(
    Guid UserId,
    IEnumerable<CartItemDto> Products);