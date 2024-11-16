using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Entities;

public class SaleItem : BaseEntity
{
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal Discount { get; private set; }
    public decimal Total { get; private set; }

    public Guid ProductId { get; private set; }
    public Guid SaleId { get; private set; }
    public Sale Sale { get; private set; }

    public void CalculateDiscount()
    {
        Discount = Quantity switch
        {
            >= 4 and < 10 => 0.1m,
            >= 10 and <= 20 => 0.2m,
            _ => 0m
        };

        Total = Quantity * UnitPrice * (1 - Discount);
    }
}