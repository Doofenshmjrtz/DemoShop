using DemoShop.Domain.Core.Order;
using DemoShop.Infrastructure.Contracts;
using DemoShop.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoShop.Application.Orders.Queries.GetOrder;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly OrderRepository _orderRepository;

    public GetOrderByIdHandler(IUnitOfWork unitOfWork, OrderRepository orderRepository)
    {
        _unitOfWork = unitOfWork;
        _orderRepository = orderRepository;
    }

    public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(
            request.OrderId,
            query => query.Include(o => o.Items),
            cancellationToken: cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return (order != null ? order : null)!;
    }
}