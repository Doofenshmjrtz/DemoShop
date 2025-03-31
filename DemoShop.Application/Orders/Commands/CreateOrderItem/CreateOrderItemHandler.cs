using DemoShop.Application.Common;
using DemoShop.Application.Orders.Queries.GetOrder;
using DemoShop.Domain.Core.Common.Abstractions;
using DemoShop.Infrastructure.Contracts;
using DemoShop.Infrastructure.Repositories;
using MediatR;

using static DemoShop.Domain.Core.Common.Abstractions.Result<long>;

namespace DemoShop.Application.Orders.Commands.CreateOrderItem;

public class CreateOrderItemHandler : BaseCommandHandler<CreateOrderItemCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly OrderRepository _orderRepository;
    private readonly IMediator _mediator;

    public CreateOrderItemHandler(IUnitOfWork unitOfWork, IMediator mediator, OrderRepository orderRepository)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _orderRepository = orderRepository;
    }
    
    public override async Task<Result<long>> Handle(CreateOrderItemCommand command, CancellationToken cancellationToken)
    {
        var order = await _mediator.Send(
            new GetOrderByIdQuery(command.OrderId), 
            cancellationToken);

        order.AddItem(
            command.Name,
            command.UnitPrice, 
            command.Quantity);

        _orderRepository.UpdateOrderItem(order);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Success(order.GetOrderItem().OrderItemId);
    }
}