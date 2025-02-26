using DemoShop.Domain.Core.Order;
using MediatR;

namespace DemoShop.Application.Orders.Queries.GetOrderList;

public sealed record GetOrderListQuery : IRequest<List<Order>>; 