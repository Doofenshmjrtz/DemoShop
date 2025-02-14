using MediatR;

namespace DemoShop.Domain.Core.Order.Queries;

public sealed record GetOrderQuery : IRequest<Order>; 