namespace Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Dtos;

public sealed record SaleItemDto(
    int Quantity,
    decimal UnitPrice,
    decimal Discount,
    decimal TotalItemAmount,
    Guid ProductId);