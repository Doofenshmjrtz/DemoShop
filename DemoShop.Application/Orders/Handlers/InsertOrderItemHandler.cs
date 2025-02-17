using DemoShop.Application.Interfaces;
using DemoShop.Application.Orders.Commands;
using DemoShop.Domain.Core.Common.Abstractions;
using DemoShop.Domain.Core.Common.Interfaces;
using DemoShop.Domain.Core.Order.Entities;

namespace DemoShop.Application.Orders.Handlers;

public class InsertOrderItemHandler : ICommandHandler<InsertCommand<OrderItem>, Result<OrderItem>>
{
    private readonly IDataAccess _data;

    public InsertOrderItemHandler(IDataAccess data) => _data = data;

    public async Task<Result<OrderItem>> Handle(InsertCommand<OrderItem> request, CancellationToken cancellationToken) => 
        Result<OrderItem>.Success(
            await Task.FromResult(
                _data.AddItem(
                    request.Name,
                    request.UnitPrice,
                    request.Quantity)
                )
            );
}