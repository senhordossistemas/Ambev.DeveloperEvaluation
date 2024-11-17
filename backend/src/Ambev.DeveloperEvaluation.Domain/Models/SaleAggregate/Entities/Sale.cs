using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Dtos;

namespace Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Entities;

public class Sale : BaseEntity
{
    private readonly List<SaleItem> _items = [];
    public string SaleNumber { get; private set; } = string.Empty;
    public decimal TotalAmount { get; private set; }
    public bool IsCancelled { get; private set; }
    public Guid? CustomerId { get; private set; }
    public Guid? BranchId { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }
    public IReadOnlyCollection<SaleItem> Items => _items;

    public void UpdateSaleDetails(decimal totalAmount, bool isCancelled, Guid? customerId, Guid? branchId)
    {
        TotalAmount = totalAmount;
        IsCancelled = isCancelled;
        CustomerId = customerId;
        BranchId = branchId;
    }

    public void UpdateItems(IEnumerable<SaleItemDto> items)
    {
        _items.Clear();
        _items.AddRange(items.Select(item => new SaleItem(item.Quantity, item.UnitPrice, item.ProductId, Id)));

        Calculate();
        UpdateTimestamp();
    }

    public void Calculate()
    {
        CalculateTotalAmount();
        CalculateDiscount();
    }

    private void CalculateTotalAmount()
    {
        TotalAmount = _items.Sum(item => item.Quantity);
    }

    private void CalculateDiscount()
    {
        foreach (var item in _items)
            item.CalculateDiscount();
    }

    public void Cancel()
    {
        if (IsCancelled)
            throw new InvalidOperationException("Sale is already cancelled.");

        IsCancelled = true;
        UpdateTimestamp();
    }

    public void CancelItem(Guid itemId)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item == null)
            throw new KeyNotFoundException($"Item with ID {itemId} not found.");

        _items.Remove(item);
        UpdateTimestamp();
        Calculate();
    }

    public void UpdateTimestamp()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}