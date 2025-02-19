using DemoShop.Domain.Core.Order.Entities;
using MediatR;

namespace DemoShop.Application.Orders.Queries;

public sealed record GetOrderItemByIdQuery(Guid Id) : IRequest<OrderItem>;