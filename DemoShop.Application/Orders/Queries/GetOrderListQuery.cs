using DemoShop.Domain.Core.Order;
using MediatR;

namespace DemoShop.Application.Orders.Queries;

public sealed record GetOrderListQuery : IRequest<List<Order>>; 