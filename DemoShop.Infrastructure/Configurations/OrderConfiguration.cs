using DemoShop.Domain.Core.Order;
using DemoShop.Domain.Core.Order.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoShop.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(o => o.Id); 
        
        builder
            .Property(o => o.OrderId)
            .ValueGeneratedOnAdd()
            .Metadata
            .SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        builder
            .Property(o => o.OrderDate)
            .IsRequired();

        builder
            .Property(o => o.OrderTotal)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder
            .Property(o => o.Status)
            .IsRequired();

        // Owned navigation for OrderItems
        builder
            .HasMany(o => o.Items)
            .WithOne()
            .HasForeignKey("OrderId")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .Metadata
            .FindNavigation(nameof(Order.Items))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}