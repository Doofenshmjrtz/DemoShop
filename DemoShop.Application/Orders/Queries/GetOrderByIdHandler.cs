using DemoShop.Application.Common.DataAccess;
using DemoShop.Domain.Core.Order;
using MediatR;

namespace DemoShop.Application.Orders.Queries;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order>
{
    private readonly IDataAccess _data;

    public GetOrderByIdHandler(IDataAccess data) => _data = data;
    
    public Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken) => Task.FromResult(_data.GetOrder(request.OrderId));
}