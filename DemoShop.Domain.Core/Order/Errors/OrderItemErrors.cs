using DemoShop.Domain.Core.Common.Abstractions;

namespace DemoShop.Domain.Core.Order.Errors;

public static class OrderItemErrors
{
    public static readonly Error AlreadyDelivered = new(
        "OrderItem.AlreadyDelivered", 
        "Item is already delivered");
    public static readonly Error AlreadyCancelled = new(
        "OrderItem.AlreadyCancelled", 
        "Item is already cancelled");
}