using DemoShop.Domain.Core.Order;
using MediatR;

namespace DemoShop.Application.Orders.Queries;

public sealed record GetOrderByIdQuery(Guid OrderId) : IRequest<Order>; 