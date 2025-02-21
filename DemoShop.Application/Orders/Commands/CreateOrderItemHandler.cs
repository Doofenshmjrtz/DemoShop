using DemoShop.Application.Common;
using DemoShop.Application.Common.DataAccess;
using DemoShop.Domain.Core.Common.Abstractions;
using static DemoShop.Domain.Core.Common.Abstractions.Result<long>;

namespace DemoShop.Application.Orders.Commands;

public class CreateOrderItemHandler : BaseCommandHandler<CreateOrderItemCommand>
{
    private readonly IDataAccess _data;

    public CreateOrderItemHandler(IDataAccess data) => _data = data;

    public override async Task<Result<long>> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken) => 
        Success(
            await Task.FromResult(
                _data.AddItem(
                    request.Name,
                    request.UnitPrice,
                    request.Quantity)
                )
            );
}