using DemoShop.Domain.Core.Common.Interfaces;
using DemoShop.Domain.Core.Common.Queries;
using O = DemoShop.Domain.Core.Order.Order;
using MediatR;

namespace DemoShop.Domain.Core.Common.Handlers;

public class GetOrderHandler : IRequestHandler<GetOrderQuery, O>
{
    private readonly IDataAccess _data;
    
    public GetOrderHandler(IDataAccess data) => _data = data;
    
    public Task<O> Handle(GetOrderQuery request, CancellationToken cancellationToken) => Task.FromResult(_data.GetOrder()); 
}