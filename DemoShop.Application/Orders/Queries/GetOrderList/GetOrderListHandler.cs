using DemoShop.Application.Common.DataAccess;
using DemoShop.Domain.Core.Order;
using MediatR;

namespace DemoShop.Application.Orders.Queries.GetOrderList;

public class GetOrderListHandler : IRequestHandler<GetOrderListQuery, List<Order>>
{
    private readonly IMediator _mediator;
    private readonly IDataAccess _data;

    public GetOrderListHandler(IMediator mediator, IDataAccess data)
    {
        _mediator = mediator;
        _data = data;
    }
    
    public Task<List<Order>> Handle(GetOrderListQuery request, CancellationToken cancellationToken) => Task.FromResult(_data.GetOrderList());
}