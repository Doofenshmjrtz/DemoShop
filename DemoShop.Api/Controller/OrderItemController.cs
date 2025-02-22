using DemoShop.Application.Orders.Commands;
using DemoShop.Application.Orders.Queries;
using DemoShop.Domain.Core.Common.Abstractions;
using DemoShop.Domain.Core.Order.Entities;
using Microsoft.AspNetCore.Mvc;
using DemoShop.Api.Filters;
using FluentValidation;
using MediatR;

namespace DemoShop.Api.Controller;

[ResultFilter]
[ApiController]
[Route("api/[controller]")]
public class OrderItemController(IMediator mediator, IServiceProvider serviceProvider) : ControllerBase
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    
    // GET api/<OrderItemController>
    [HttpGet]
    public async Task<ActionResult<List<OrderItem>>> Get() => await mediator.Send(new GetOrderItemListQuery());
    
    // GET api/<OrderItemController>/<Id>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OrderItem>> Get([FromRoute] Guid id)
    {
        var query = new GetOrderItemByIdQuery(id);

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

        var result = await mediator.Send(query);
        return Ok(result);
    }
    
    // POST api/<OrderItemController>
    [HttpPost]
    public async Task<ActionResult<Result<long>>> Post([FromBody] OrderItemDto orderItem)
    {
        var command = new CreateOrderItemCommand(orderItem.Name, orderItem.UnitPrice, orderItem.Quantity);
        
        var validator = _serviceProvider.GetService<IValidator<CreateOrderItemCommand>>();

        if (validator == null) 
            return await mediator.Send(command);
        
        var validationResult = await validator.ValidateAsync(command);
        
        if (!validationResult.IsValid)
            return BadRequest(validationResult
                .Errors
                .Select(e => e.ErrorMessage)
            );

        return await mediator.Send(command);
    } 
}