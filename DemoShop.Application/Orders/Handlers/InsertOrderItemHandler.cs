using DemoShop.Application.Interfaces;
using DemoShop.Application.Orders.Commands;
using DemoShop.Domain.Core.Common.Abstractions;
using DemoShop.Domain.Core.Common.Interfaces;

namespace DemoShop.Application.Orders.Handlers;

public class InsertOrderItemHandler : ICommandHandler<InsertOrderItemCommand>
{
    private readonly IDataAccess _data;
    
    public InsertOrderItemHandler(IDataAccess data) => _data = data;

    public async Task<Result> Handle(InsertOrderItemCommand request, CancellationToken cancellationToken)
    {
        await Task.FromResult(_data.AddItem(request.Name, request.UnitPrice, request.Quantity));
        return Result.Success();
    }
}

public class InsertOrderItemHandler<OrderItem> : ICommandHandler<InsertOrderItemCommand, Result<OrderItem>>
    where OrderItem : Entity
{
    private readonly IDataAccess _data;

    public InsertOrderItemHandler(IDataAccess data) => _data = data;

    public async Task<Result<Result<OrderItem>>> Handle(InsertOrderItemCommand<OrderItem> request, CancellationToken cancellationToken)
    {
        var orderItem = await Task.FromResult(_data.AddItem<OrderItem>(request.Name, request.UnitPrice, request.Quantity));

        return Result<OrderItem>.Success(orderItem);
    }
}