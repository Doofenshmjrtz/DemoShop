using DemoShop.Domain.Core.Common.Models;
using DemoShop.Domain.Core.Order.Enums;

namespace DemoShop.Domain.Core.Order.Entities;

public class OrderItem : Entity
{
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }
    public decimal Subtotal {get; private set;}
    public OrderItemStatus Status { get; private set; }
    
    private OrderItem(decimal unitPrice, int quantity)
    {
        UnitPrice = unitPrice;
        Quantity = quantity;
        Subtotal = UnitPrice * Quantity;
        Status = OrderItemStatus.InProgress;
    }

    public static OrderItem Create(decimal unitPrice, int quantity) => new OrderItem(unitPrice, quantity);

    public void MarkAsDelivered()
    {
        if (Status == OrderItemStatus.Delivered)
            throw new InvalidOperationException("Item is already delivered");
        
        Status = OrderItemStatus.Delivered;
    }
    
    public void MarkAsCancelled()
    {
        Status = Status switch
        {
            OrderItemStatus.Delivered => throw new InvalidOperationException("Cannot cancel a delivered order"),
            OrderItemStatus.Cancelled => throw new InvalidOperationException("Item is already cancelled"),
            _ => OrderItemStatus.Cancelled
        };
    }
}