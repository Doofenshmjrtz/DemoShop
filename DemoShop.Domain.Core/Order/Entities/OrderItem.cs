using System.Text.Json.Serialization;
using DemoShop.Domain.Core.Common.Abstractions;
using DemoShop.Domain.Core.Order.Enums;

using static DemoShop.Domain.Core.Common.Abstractions.Result;
using static DemoShop.Domain.Core.Order.Errors.OrderItemErrors;

namespace DemoShop.Domain.Core.Order.Entities;

public class OrderItem : Entity
{
    public string Name { get; private set; }
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }
    public decimal Subtotal {get; private set;}
    public OrderItemStatus Status { get; private set; }
    
    [JsonConstructor]
    private OrderItem(string name, decimal unitPrice, int quantity)
    {
        Name = name;
        UnitPrice = unitPrice;
        Quantity = quantity;
        Subtotal = UnitPrice * Quantity;
        Status = OrderItemStatus.InProgress;
    }

    public static OrderItem Create(string name, decimal unitPrice, int quantity) => new OrderItem(name, unitPrice, quantity);

    public Result MarkAsDelivered()
    {
        if (Status == OrderItemStatus.Delivered)
            return Failure(AlreadyDelivered);
        
        Status = OrderItemStatus.Delivered;
        return Success();
    }
    
    public Result MarkAsCancelled()
    {
        switch (Status)
        {
            case OrderItemStatus.Delivered:
                return Failure(AlreadyDelivered);
            case OrderItemStatus.Cancelled:
                return Failure(AlreadyCancelled);
            case OrderItemStatus.InProgress:
            default:
                Status = OrderItemStatus.Cancelled;
                return Success();
        }
    }
}