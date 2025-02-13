using MediatR;

namespace DemoShop.Domain.Core.Common.Queries;

public record GetOrderListQuery() : IRequest<List<Order.Order>>;