using DemoShop.Application.Common;
using DemoShop.Application.Common.DataAccess;
using DemoShop.Domain.Core.Common.Abstractions;
using DemoShop.Domain.Core.Order;
using DemoShop.Infrastructure;
using DemoShop.Infrastructure.Contracts;

using static DemoShop.Domain.Core.Common.Abstractions.Result<long>;

namespace DemoShop.Application.Orders.Commands.CreateOrder;

public class CreateOrderHandler : BaseCommandHandler<CreateOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderHandler(IUnitOfWork unitOfWork) 
        => _unitOfWork = unitOfWork;
    
    public override async Task<Result<long>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var orderRepository = _unitOfWork.GetRepository<Order>();
        
        var order = Order.Create();
        
        await orderRepository.AddAsync(order);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Success(
            await Task.FromResult(orderRepository.GetAsync(order.Id, cancellationToken: cancellationToken).Result!.OrderId)
            );
    }
}