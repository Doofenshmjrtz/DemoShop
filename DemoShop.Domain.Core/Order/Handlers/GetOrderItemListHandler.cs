using DemoShop.Domain.Core.Common.Interfaces;
using DemoShop.Domain.Core.Order.Entities;
using DemoShop.Domain.Core.Order.Queries;
using MediatR;

namespace DemoShop.Domain.Core.Order.Handlers;

public class GetOrderItemListHandler(IDataAccess data) : IRequestHandler<GetOrderItemListQuery, List<OrderItem>>
{
    public Task<List<OrderItem>> Handle(GetOrderItemListQuery request, CancellationToken cancellationToken) => Task.FromResult(data.GetOrderItems()); 
}