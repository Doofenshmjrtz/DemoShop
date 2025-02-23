using DemoShop.Application.Common.DataAccess;
using DemoShop.Domain.Core.Order.Entities;
using MediatR;

namespace DemoShop.Application.Orders.Queries;

public class GetOrderItemByIdHandler : IRequestHandler<GetOrderItemByIdQuery, OrderItem>
{
    private readonly IDataAccess _data;

    public GetOrderItemByIdHandler(IDataAccess data) => _data = data;
    
    public async Task<OrderItem> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken) => 
        await Task.FromResult(_data.GetOrderItem(request.OrderItemId));
}