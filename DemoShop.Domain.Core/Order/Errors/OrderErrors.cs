using DemoShop.Domain.Core.Common.Abstractions;

namespace DemoShop.Domain.Core.Order.Errors;

public class OrderErrors
{
    public static readonly Error NotFound = new(
        "Order.NotFound", 
        "Order not found.");
}