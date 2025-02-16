using DemoShop.Domain.Core.Order;
using MediatR;

namespace DemoShop.Application.Orders.Queries;

public sealed record GetOrderQuery : IRequest<Order>; 