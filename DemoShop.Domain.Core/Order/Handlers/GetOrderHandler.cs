using DemoShop.Domain.Core.Common.Interfaces;
using DemoShop.Domain.Core.Order.Queries;
using MediatR;

namespace DemoShop.Domain.Core.Order.Handlers;

public class GetOrderHandler(IDataAccess data) : IRequestHandler<GetOrderQuery, Order>
{
    public Task<Order> Handle(GetOrderQuery request, CancellationToken cancellationToken) => Task.FromResult(data.GetOrder()); 
}