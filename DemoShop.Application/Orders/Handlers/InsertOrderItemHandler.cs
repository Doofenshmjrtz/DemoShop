using DemoShop.Application.Interfaces;
using DemoShop.Application.Orders.Commands;
using DemoShop.Domain.Core.Common.Abstractions;
using DemoShop.Domain.Core.Common.Interfaces;

using static DemoShop.Domain.Core.Common.Abstractions.Result<long>;

namespace DemoShop.Application.Orders.Handlers;

public class InsertOrderItemHandler : ICommandHandler<InsertCommand, Result<long>>
{
    private readonly IDataAccess _data;

    public InsertOrderItemHandler(IDataAccess data) => _data = data;

    public async Task<Result<long>> Handle(InsertCommand request, CancellationToken cancellationToken) => 
        Success(
            await Task.FromResult(
                _data.AddItem(
                    request.Name,
                    request.UnitPrice,
                    request.Quantity)
                )
            );
}