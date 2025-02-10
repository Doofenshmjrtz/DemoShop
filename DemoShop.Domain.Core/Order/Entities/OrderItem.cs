using DemoShop.Domain.Core.Common.Models;

namespace DemoShop.Domain.Core.Order.Entities;

public class OrderItem : Entity
{
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }
    public decimal Subtotal {get; private set;}
    public bool IsDelivered { get; private set; }
    
    private OrderItem(decimal unitPrice, int quantity)
    {
        UnitPrice = unitPrice;
        Quantity = quantity;
        Subtotal = UnitPrice * Quantity;
        IsDelivered = false;
    }

    public static OrderItem Create(decimal unitPrice, int quantity) => new OrderItem(unitPrice, quantity);

    public void MarkItemAsDelivered() => IsDelivered = true;
}