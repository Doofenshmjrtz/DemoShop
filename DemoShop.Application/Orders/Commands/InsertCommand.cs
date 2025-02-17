using DemoShop.Application.Interfaces;
using DemoShop.Domain.Core.Common.Abstractions;

namespace DemoShop.Application.Orders.Commands;

public sealed record InsertCommand<TResponse>(string Name, decimal UnitPrice, int Quantity) : ICommand<Result<TResponse>>;

