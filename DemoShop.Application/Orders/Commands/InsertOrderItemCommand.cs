using DemoShop.Application.Interfaces;

namespace DemoShop.Application.Orders.Commands;

public sealed record InsertOrderItemCommand(string Name, decimal UnitPrice, int Quantity) : ICommand;
public sealed record InsertOrderItemCommand<TOrderItem>(string Name, decimal UnitPrice, int Quantity) : ICommand<TOrderItem>;

