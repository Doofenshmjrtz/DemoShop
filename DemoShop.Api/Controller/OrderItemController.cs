using DemoShop.Domain.Core.Common.Abstractions;
using DemoShop.Domain.Core.Order.Entities;
using Microsoft.AspNetCore.Mvc;
using DemoShop.Api.Filters;
using DemoShop.Api.Models;
using DemoShop.Application.Orders.Commands.CreateOrderItem;
using DemoShop.Application.Orders.Queries.GetOrderItem;
using DemoShop.Application.Orders.Queries.GetOrderItemList;
using FluentValidation;
using MediatR;

namespace DemoShop.Api.Controller;

[ResultFilter]
[ApiController]
[Route("api/[controller]")]
public class OrderItemController : ControllerBase
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IMediator _mediator;

    public OrderItemController(IMediator mediator, IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _mediator = mediator;
    }
     
    // GET api/<OrderItemController>/list/<Id>
    [HttpGet("list/{orderId:guid}")]
    public async Task<ActionResult<List<OrderItem>>> GetAll([FromRoute] Guid orderId) => await _mediator.Send(new GetOrderItemListQuery(orderId));
    
    // GET api/<OrderItemController>/<Id>
    [HttpGet("{orderItemId:guid}")]
    public async Task<ActionResult<OrderItem>> Get([FromRoute] Guid orderItemId)
    {
        var query = new GetOrderItemByIdQuery(orderItemId);

        var validator = _serviceProvider.GetService<IValidator<GetOrderItemByIdQuery>>();

        if (validator != null)
        {
            var validationResult = await validator.ValidateAsync(query);
            if (!validationResult.IsValid)
                return BadRequest(validationResult
                    .Errors
                    .Select(e => e.ErrorMessage)
                );
        }

        var result = await _mediator.Send(query);
        return Ok(result);
    }
    
    // POST api/<OrderItemController>/<Id>
    [HttpPost("{orderId:guid}")]
    public async Task<ActionResult<Result<long>>> Post([FromRoute] Guid orderId, [FromBody] OrderItemDto orderItem)
    {
        var command = new CreateOrderItemCommand(orderId, orderItem.Name, orderItem.UnitPrice, orderItem.Quantity);
        
        var validator = _serviceProvider.GetService<IValidator<CreateOrderItemCommand>>();

        if (validator == null) 
            return await _mediator.Send(command);
        
        var validationResult = await validator.ValidateAsync(command);
        
        if (!validationResult.IsValid)
            return BadRequest(validationResult
                .Errors
                .Select(e => e.ErrorMessage)
            );

        return await _mediator.Send(command);
    } 
}