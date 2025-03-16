using DemoShop.Application.Common;

namespace DemoShop.Application.Orders.Commands.CreateOrderItem;

public sealed class CreateOrderItemCommand(Guid orderId, string name, decimal unitPrice, int quantity) : BaseCommand
{
    public Guid OrderId { get; private set; } = orderId;
    public string Name { get; private set; } = name;
    public decimal UnitPrice { get; private set; } = unitPrice;
    public int Quantity { get; private set; } = quantity;
}

