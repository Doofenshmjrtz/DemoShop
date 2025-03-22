using DemoShop.Application.Common;
using DemoShop.Application.Orders.Queries.GetOrder;
using DemoShop.Domain.Core.Common.Abstractions;
using DemoShop.Domain.Core.Order;
using DemoShop.Domain.Core.Order.Entities;
using DemoShop.Infrastructure.Contracts;
using MediatR;

using static DemoShop.Domain.Core.Common.Abstractions.Result<long>;

namespace DemoShop.Application.Orders.Commands.CreateOrderItem;

public class CreateOrderItemHandler : BaseCommandHandler<CreateOrderItemCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    public CreateOrderItemHandler(IUnitOfWork unitOfWork, IMediator mediator)
    {
         _unitOfWork = unitOfWork;
         _mediator = mediator;
    }
    
    public override async Task<Result<long>> Handle(CreateOrderItemCommand command, CancellationToken cancellationToken)
    {
        var orderRepository =  _unitOfWork.GetRepository<Order>();
        
        var order = await _mediator.Send(
            new GetOrderByIdQuery(command.OrderId), 
            cancellationToken);

        order.AddItem(
            command.Name,
            command.UnitPrice, 
            command.Quantity);
        
        // await orderItemRepository.AddAsync(order.GetOrderItem());
        orderRepository.Update(order);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Success(order.OrderId);
    }
}