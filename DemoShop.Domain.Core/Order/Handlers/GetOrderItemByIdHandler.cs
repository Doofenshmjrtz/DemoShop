using DemoShop.Domain.Core.Order.Entities;
using DemoShop.Domain.Core.Order.Queries;
using MediatR;

namespace DemoShop.Domain.Core.Order.Handlers;

public class GetOrderItemByIdHandler : IRequestHandler<GetOrderItemByIdQuery, OrderItem>
{
    private readonly IMediator _mediator;

    public GetOrderItemByIdHandler(IMediator mediator) => _mediator = mediator;
    
    public async Task<OrderItem> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
    { 
        var results = await _mediator.Send(new GetOrderItemListQuery(), cancellationToken);
        var output = results.FirstOrDefault(x => x.Id == request.Id);
        return output == null ? null! : // This will trigger BadRequest() in the controller
            output;
    }
}