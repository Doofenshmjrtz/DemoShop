using DemoShop.Application.Common;
using DemoShop.Domain.Core.Common.Abstractions;

namespace DemoShop.Application.Orders.Commands;

public sealed class InsertCommand(string name, decimal unitPrice, int quantity) : BaseCommand<Result<long>>
{
    public string Name { get; init; } = name;
    public decimal UnitPrice { get; init; } = unitPrice;
    public int Quantity { get; init; } = quantity;
}

