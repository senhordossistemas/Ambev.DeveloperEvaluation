﻿using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(s => s.SaleNumber).IsRequired().HasMaxLength(50);
        builder.Property(s => s.TotalAmount).IsRequired();
        builder.Property(s => s.IsCancelled).IsRequired().HasDefaultValue(false);
        builder.Property(s => s.CustomerId);
        builder.Property(s => s.BranchId);
        builder.Property(u => u.CreatedAt).HasColumnType("timestamp with time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();
        builder.Property(u => u.UpdatedAt).HasColumnType("timestamp with time zone");

        builder.HasMany(s => s.Items)
            .WithOne(i => i.Sale)
            .HasForeignKey(i => i.SaleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}