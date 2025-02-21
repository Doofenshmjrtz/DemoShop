using DemoShop.Application.Common.DataAccess;
using DemoShop.Domain.Core.Order.Entities;
using MediatR;

namespace DemoShop.Application.Orders.Queries;

public class GetOrderItemListHandler(IDataAccess data) : IRequestHandler<GetOrderItemListQuery, List<OrderItem>>
{
    public Task<List<OrderItem>> Handle(GetOrderItemListQuery request, CancellationToken cancellationToken) => Task.FromResult(data.GetOrderItems()); 
}