using MediatR;
using O = DemoShop.Domain.Core.Order.Order;

namespace DemoShop.Domain.Core.Common.Queries;

public record GetOrderQuery() : IRequest<O>; 