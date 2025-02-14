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
    public async Task<List<OrderItem>> Get() => await mediator.Send(new GetOrderItemListQuery());
    
    // GET api/<OrderItemController>/<Id>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OrderItem>> Get(Guid id)
    {
        try 
        {
            var result = await mediator.Send(new GetOrderItemByIdQuery(id));
            return Ok(result);
        }
        catch (NullReferenceException)
        {
            return NotFound();
        }
    }
}