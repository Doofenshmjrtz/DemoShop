using DemoShop.Application.Common;
using DemoShop.Domain.Core.Common.Abstractions;
using DemoShop.Domain.Core.Order;
using DemoShop.Domain.Core.Order.Entities;
using DemoShop.Infrastructure.Contracts;

using static DemoShop.Domain.Core.Common.Abstractions.Result<long>;
using static DemoShop.Domain.Core.Order.Errors.OrderErrors;

namespace DemoShop.Application.Orders.Commands.CreateOrderItem;

public class CreateOrderItemHandler : BaseCommandHandler<CreateOrderItemCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderItemHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    
    public override async Task<Result<long>> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        var orderRepository = _unitOfWork.GetRepository<Order>();
        var orderItemRepository = _unitOfWork.GetRepository<OrderItem>();
            
        // Retrieve the order to ensure it exists
        var order = await orderRepository.GetAsync(request.OrderId);
        if (order == null) 
            return Failure(NotFound);

        // Create new OrderItem
        order.AddItem(request.Name, request.UnitPrice, request.Quantity);
        var orderItem = order.GetOrderItem(); 

        // Add to repository
        await orderItemRepository.AddAsync(orderItem);
        await orderRepository.UpdateAsync(order.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Success(orderItem.OrderItemId);
    }
}