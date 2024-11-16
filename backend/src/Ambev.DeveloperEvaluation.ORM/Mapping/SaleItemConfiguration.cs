﻿using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable("SaleItems");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(s => s.Quantity).IsRequired().HasMaxLength(20);
        builder.Property(s => s.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(s => s.Discount).HasColumnType("decimal(18,2)");
        builder.Property(s => s.TotalItemAmount).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(s => s.ProductId).IsRequired();
        builder.Property(s => s.SaleId).IsRequired();

        builder.HasOne(s => s.Sale)
            .WithMany(s => s.Items)
            .HasForeignKey(i => i.SaleId);
    }
}