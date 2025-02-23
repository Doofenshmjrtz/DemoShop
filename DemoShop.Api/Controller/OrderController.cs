using DemoShop.Application.Orders.Commands;
using DemoShop.Application.Orders.Queries;
using DemoShop.Domain.Core.Common.Abstractions;
using DemoShop.Domain.Core.Order;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // GET api/<OrderController>
    [HttpGet]
    public async Task<List<Order>> Get() => await _mediator.Send(new GetOrderListQuery());
    
    // GET api/<OrderController>/<Id>
    [HttpGet("{orderId:guid}")]
    public async Task<Order> Get([FromRoute] Guid orderId) => await _mediator.Send(new GetOrderByIdQuery(orderId));
    
    // POST api/OrderController
    [HttpPost]
    public async Task<Result<long>> Post() => await _mediator.Send(new CreateOrderCommand());
}