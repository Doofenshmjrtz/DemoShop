using DemoShop.Domain.Core.Order;
using DemoShop.Infrastructure.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoShop.Application.Orders.Queries.GetOrder;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOrderByIdHandler(IUnitOfWork unitOfWork) 
        => _unitOfWork = unitOfWork;
    
    public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var orderRepository =  _unitOfWork.GetRepository<Order>();
        
        var order = await orderRepository.GetAsync(
            request.OrderId,
            query => query.Include(o => o.Items),
            cancellationToken: cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return (order != null ? order : null)!;
    }
}