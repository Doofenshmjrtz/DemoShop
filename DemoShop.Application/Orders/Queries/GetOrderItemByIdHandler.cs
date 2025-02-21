using DemoShop.Domain.Core.Order.Entities;
using MediatR;

namespace DemoShop.Application.Orders.Queries;

public class GetOrderItemByIdHandler : IRequestHandler<GetOrderItemByIdQuery, OrderItem>
{
    private readonly IMediator _mediator;

    public GetOrderItemByIdHandler(IMediator mediator) => _mediator = mediator;
    
    public async Task<OrderItem> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
    { 
        var results = await _mediator.Send(new GetOrderItemListQuery(), cancellationToken);
        return results.FirstOrDefault(x => x.Id == request.Id)!;
    }
}