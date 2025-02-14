using DemoShop.Domain.Core.Order.Entities;
using MediatR;

namespace DemoShop.Domain.Core.Order.Queries;

public sealed record GetOrderItemListQuery : IRequest<List<OrderItem>>;