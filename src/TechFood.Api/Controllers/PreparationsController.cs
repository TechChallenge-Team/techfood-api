using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechFood.Application.Preparations.Commands.CompletePreparation;
using TechFood.Application.Preparations.Commands.StartPreparation;
using TechFood.Application.Preparations.Queries.GetDailyPreparations;
using TechFood.Application.Preparations.Queries.GetPreparation;
using TechFood.Application.Preparations.Queries.GetTrackingPreparations;

namespace TechFood.Api.Controllers;

[ApiController()]
[Route("v1/[controller]")]
public class PreparationsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetDailyAsync()
    {
        var query = new GetDailyPreparationsQuery();

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet]
    [Route("tracking")]
    public async Task<IActionResult> GetTrackingAsync()
    {
        var query = new GetTrackingPreparationsQuery();

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var query = new GetPreparationQuery(id);

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPatch]
    [Route("{id:guid}/start")]
    public async Task<IActionResult> StartAsync(Guid id)
    {
        var command = new StartPreparationCommand(id);

        await _mediator.Send(command);

        return Ok();
    }

    [HttpPatch]
    [Route("{id:guid}/complete")]
    public async Task<IActionResult> CompleteAsync(Guid id)
    {
        var command = new CompletePreparationCommand(id);

        await _mediator.Send(command);

        return Ok();
    }
}
