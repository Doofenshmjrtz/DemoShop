using DemoShop.Domain.Core.Order.Commands;
using DemoShop.Domain.Core.Order.Entities;
using DemoShop.Domain.Core.Order.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class OrderItemController(IMediator mediator) : ControllerBase
{
    // GET api/<OrderItemController>
    [HttpGet]
    public async Task<ActionResult<List<OrderItem>>> Get() => await mediator.Send(new GetOrderItemListQuery());
    
    // GET api/<OrderItemController>/<Id>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OrderItem>> Get([FromRoute] Guid id)
    {
        try 
        {
            var result = await mediator.Send(new GetOrderItemByIdQuery(id));
            return Ok(result);
        }
        catch (NullReferenceException)
        {
            return BadRequest("Invalid ID");
        }
    }
    
    // POST api/<OrderItemController>
    [HttpPost]
    public async Task<ActionResult<OrderItem>> Post([FromBody] OrderItem orderItem) => 
        await mediator.Send(new InsertOrderItemCommand(orderItem.Name, orderItem.UnitPrice, orderItem.Quantity));
}