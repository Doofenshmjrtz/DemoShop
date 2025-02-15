using DemoShop.Domain.Core.Order.Entities;
using MediatR;

namespace DemoShop.Domain.Core.Order.Commands;

public sealed record InsertOrderItemCommand(string Name, decimal UnitPrice, int Quantity) : IRequest<OrderItem>;