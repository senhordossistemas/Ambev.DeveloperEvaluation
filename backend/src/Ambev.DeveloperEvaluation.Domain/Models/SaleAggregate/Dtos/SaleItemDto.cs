namespace Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Dtos;

public sealed record SaleItemDto(
    Guid Id,
    int Quantity,
    decimal UnitPrice,
    decimal Discount,
    decimal TotalItemAmount,
    Guid ProductId)
{
    public SaleItemDto() : this(default, 0, 0, 0, 0, Guid.Empty) { }
}