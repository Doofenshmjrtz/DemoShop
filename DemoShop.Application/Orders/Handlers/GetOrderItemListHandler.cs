using DemoShop.Application.Orders.Queries;
using DemoShop.Domain.Core.Common.Interfaces;
using DemoShop.Domain.Core.Order.Entities;
using MediatR;

namespace DemoShop.Application.Orders.Handlers;

public class GetOrderItemListHandler(IDataAccess data) : IRequestHandler<GetOrderItemListQuery, List<OrderItem>>
{
    public Task<List<OrderItem>> Handle(GetOrderItemListQuery request, CancellationToken cancellationToken) => Task.FromResult(data.GetOrderItems()); 
}