using DemoShop.Application.Common.DataAccess;
using DemoShop.Domain.Core.Order;
using MediatR;

namespace DemoShop.Application.Orders.Queries;

public class GetOrderHandler(IDataAccess data) : IRequestHandler<GetOrderQuery, Order>
{
    public Task<Order> Handle(GetOrderQuery request, CancellationToken cancellationToken) => Task.FromResult(data.GetOrder()); 
}