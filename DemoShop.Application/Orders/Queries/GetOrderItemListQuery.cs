using DemoShop.Domain.Core.Order.Entities;
using MediatR;

namespace DemoShop.Application.Orders.Queries;

public sealed record GetOrderItemListQuery(Guid OrderId) : IRequest<List<OrderItem>>;