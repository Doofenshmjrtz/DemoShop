using DemoShop.Domain.Core.Order;
using MediatR;

namespace DemoShop.Application.Orders.Queries.GetOrder;

public sealed record GetOrderByIdQuery(Guid OrderId) : IRequest<Order>; 