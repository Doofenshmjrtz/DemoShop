using DemoShop.Domain.Core.Common.Interfaces;
using DemoShop.Domain.Core.Order.Commands;
using DemoShop.Domain.Core.Order.Entities;
using MediatR;

namespace DemoShop.Domain.Core.Order.Handlers;

public class InsertOrderItemHandler : IRequestHandler<InsertOrderItemCommand, OrderItem>
{
    private readonly IDataAccess _data;
    
    public InsertOrderItemHandler(IDataAccess data) => _data = data;
    
    public Task<OrderItem> Handle(InsertOrderItemCommand request, CancellationToken cancellationToken) => 
        Task.FromResult(_data.AddItem(request.Name, request.UnitPrice, request.Quantity));
}