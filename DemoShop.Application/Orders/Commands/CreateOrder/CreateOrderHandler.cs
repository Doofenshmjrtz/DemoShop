using DemoShop.Application.Common;
using DemoShop.Application.Common.DataAccess;
using DemoShop.Domain.Core.Common.Abstractions;
using DemoShop.Domain.Core.Order;
using DemoShop.Domain.Core.Order.Interfaces;
using DemoShop.Infrastructure;
using DemoShop.Infrastructure.Contracts;
using DemoShop.Infrastructure.Repositories;
using static DemoShop.Domain.Core.Common.Abstractions.Result<long>;

namespace DemoShop.Application.Orders.Commands.CreateOrder;

public class CreateOrderHandler : BaseCommandHandler<CreateOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly OrderRepository _orderRepository;

    public CreateOrderHandler(IUnitOfWork unitOfWork, OrderRepository orderRepository)
    {
        _unitOfWork = unitOfWork;
        _orderRepository = orderRepository;
    }

    public override async Task<Result<long>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        
        var order = Order.Create();
        
        await _orderRepository.AddAsync(order);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Success(
            await Task
                .FromResult(_orderRepository
                        .GetByIdAsync(order.Id, cancellationToken: cancellationToken)
                        .Result!
                        .OrderId)
            );
    }
}