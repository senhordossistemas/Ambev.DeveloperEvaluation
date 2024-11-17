﻿using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Dtos;

namespace Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Entities;

public class Sale : BaseEntity
{
    public string SaleNumber { get; private set; } = string.Empty;
    public decimal TotalAmount { get; private set; }
    public bool IsCancelled { get; private set; }
    public Guid? CustomerId { get; private set; }
    public Guid? BranchId { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }

    private readonly List<SaleItem> _items = [];
    public IReadOnlyCollection<SaleItem> Items => _items;

    public void Calculate()
    {
        CalculateTotalAmount();
        CalculateDiscount();
    }

    private void CalculateTotalAmount()
        => TotalAmount = _items.Sum(item => item.Quantity);

    private void CalculateDiscount()
    {
        foreach (var item in _items)
            item.CalculateDiscount();
    }

    public void Cancel() => IsCancelled = true;
    
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
        _items.AddRange(items.Select(item => new SaleItem( item.Quantity, item.UnitPrice, item.ProductId, Id)));
        
        Calculate();
        UpdateTimestamp();
    }

    public void UpdateTimestamp() => UpdatedAt = DateTime.UtcNow;

}