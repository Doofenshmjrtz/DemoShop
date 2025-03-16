using DemoShop.Domain.Core.Order.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoShop.Infrastructure.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");

        builder.HasKey(oi => oi.Id);

        builder.Property(oi => oi.OrderItemId)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(oi => oi.OrderId)
            .IsRequired();

        builder.Property(oi => oi.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(oi => oi.UnitPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(oi => oi.Quantity)
            .IsRequired();

        builder.Property(oi => oi.Subtotal)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(oi => oi.Status)
            .IsRequired();
    }
}