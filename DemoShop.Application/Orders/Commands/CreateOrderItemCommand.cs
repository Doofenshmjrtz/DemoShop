using DemoShop.Application.Common;

namespace DemoShop.Application.Orders.Commands;

public sealed class CreateOrderItemCommand(string name, decimal unitPrice, int quantity) : BaseCommand
{
    public string Name { get; init; } = name;
    public decimal UnitPrice { get; init; } = unitPrice;
    public int Quantity { get; init; } = quantity;
}

