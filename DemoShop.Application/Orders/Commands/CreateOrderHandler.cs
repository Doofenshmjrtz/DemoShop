using DemoShop.Application.Common;
using DemoShop.Application.Common.DataAccess;
using DemoShop.Domain.Core.Common.Abstractions;
using static DemoShop.Domain.Core.Common.Abstractions.Result<long>;


namespace DemoShop.Application.Orders.Commands;

public class CreateOrderHandler : BaseCommandHandler<CreateOrderCommand>
{
    private readonly IDataAccess _data;

    public CreateOrderHandler(IDataAccess data) => _data = data;
    
    public override async Task<Result<long>> Handle(CreateOrderCommand request, CancellationToken cancellationToken) => 
        Success(
            await Task.FromResult(
                _data.CreateOrder()));
}