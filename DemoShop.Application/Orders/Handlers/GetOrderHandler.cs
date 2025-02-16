using DemoShop.Application.Orders.Queries;
using DemoShop.Domain.Core.Common.Interfaces;
using DemoShop.Domain.Core.Order;
using MediatR;

namespace DemoShop.Application.Orders.Handlers;

public class GetOrderHandler(IDataAccess data) : IRequestHandler<GetOrderQuery, Order>
{
    public Task<Order> Handle(GetOrderQuery request, CancellationToken cancellationToken) => Task.FromResult(data.GetOrder()); 
}