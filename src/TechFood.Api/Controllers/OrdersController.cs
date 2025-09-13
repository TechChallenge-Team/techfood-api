using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechFood.Application.Orders.Commands.CreateOrder;
using TechFood.Application.Orders.Commands.DeliverOrder;
using TechFood.Application.Orders.Queries.GetOrders;
using TechFood.Application.Orders.Queries.GetReadyOrders;
using TechFood.Contracts.Orders;

namespace TechFood.Api.Controllers;

[ApiController()]
[Route("v1/[controller]")]
public class OrdersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateOrderRequest request)
    {
        var command = new CreateOrderCommand(
            request.CustomerId,
            request.Items.ConvertAll(
                item => new CreateOrderCommand.Item(
                    item.ProductId,
                    item.Quantity)));

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var query = new GetOrdersQuery();

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet]
    [Route("ready")]
    public async Task<IActionResult> GetReadyAsync()
    {
        var query = new GetReadyOrdersQuery();

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPatch]
    [Route("{id:guid}/deliver")]
    public async Task<IActionResult> DeliverAsync(Guid id)
    {
        var command = new DeliverOrderCommand(id);

        await _mediator.Send(command);

        return Ok();
    }
}
