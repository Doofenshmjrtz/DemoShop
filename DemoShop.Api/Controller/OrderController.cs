using DemoShop.Domain.Core.Common.Queries;
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
    public async Task<Order> Get() => await _mediator.Send(new GetOrderQuery());
    
    // GET api/<OrderController>/<Id>
    [HttpGet("{id:int}")]
    public string Get(int id) => $"value {id}";
    
    // POST api/<OrderController>
    [HttpPost]
    public void Post([FromBody] string value){}
    
    [HttpPut("{id:int}")]
    // PUT api/<PersonController>/<Id>
    public void Put(int id, [FromBody] string value){}
    
    [HttpDelete("{id:int}")]
    // Delete api/<PersonController>/<Id>
    public void Delete(int id){}
}