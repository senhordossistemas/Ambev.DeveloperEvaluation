using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Dtos;
using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Dtos;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Queries.GetCart;

public sealed record GetCartResult(
    Guid Id,
    Guid UserId,
    DateTime CreatAt,
    IEnumerable<CartItemDto> Products);