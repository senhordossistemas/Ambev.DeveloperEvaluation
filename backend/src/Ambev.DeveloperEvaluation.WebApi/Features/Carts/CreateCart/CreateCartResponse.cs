using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Dtos;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public sealed record CreateCartResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<CartItemDto> Products { get; set; } = [];
}