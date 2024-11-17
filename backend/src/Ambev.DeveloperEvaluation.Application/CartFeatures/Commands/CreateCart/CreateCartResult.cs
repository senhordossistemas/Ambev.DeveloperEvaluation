using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Dtos;

namespace Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.CreateCart;

public sealed record CreateCartResult
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<CartItemDto>? Products { get; set; }
}