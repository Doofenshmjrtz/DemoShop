using DemoShop.Application.Common;

namespace DemoShop.Application.Orders.Commands;

public sealed class CreateOrderItemCommand(Guid id, string name, decimal unitPrice, int quantity) : BaseCommand
{
    public Guid Id { get; init; } = id;
    public string Name { get; init; } = name;
    public decimal UnitPrice { get; init; } = unitPrice;
    public int Quantity { get; init; } = quantity;
}

