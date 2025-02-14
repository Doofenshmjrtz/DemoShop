using DemoShop.Domain.Core.Order;
using DemoShop.Domain.Core.Order.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IMediator mediator) : ControllerBase
{
    // GET api/<OrderController>
    [HttpGet]
    public async Task<Order> Get() => await mediator.Send(new GetOrderQuery());
}