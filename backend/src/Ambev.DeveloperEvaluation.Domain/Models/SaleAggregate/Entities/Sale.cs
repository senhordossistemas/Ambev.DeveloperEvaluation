﻿using Ambev.DeveloperEvaluation.Domain.Common;

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

    public void UpdateItems(SaleItem[] items)
    {
        _items.RemoveAll(x => items.All(itemScreen => itemScreen.ProductId != x.ProductId));

        foreach (var itemScreen in items)
        {
            var existingItem = _items.Find(item => item.ProductId == itemScreen.ProductId);

            if (existingItem is not null)
                existingItem.Update(itemScreen);
            else
                _items.Add(itemScreen);
        }

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

    public void AddItem(SaleItem item)
    {
        _items.Add(item);
    }
}