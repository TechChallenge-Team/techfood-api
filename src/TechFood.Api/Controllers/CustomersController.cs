using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechFood.Application.Customers.Commands.CreateCustomer;
using TechFood.Application.Customers.Queries.GetCustomerByDocument;
using TechFood.Contracts.Customers;
using TechFood.Domain.Enums;

namespace TechFood.Lambda.Customers.Controllers;

[ApiController()]
[Route("v1/[controller]")]
public class CustomersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCustomerRequest request)
    {
        var command = new CreateCustomerCommand(
            request.CPF,
            request.Name,
            request.Email);

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet("{document}")]
    public async Task<IActionResult> GetByDocumentAsync(string document)
    {
        var query = new GetCustomerByDocumentQuery(DocumentType.CPF, document);

        var result = await _mediator.Send(query);

        return result != null
            ? Ok(result)
            : NotFound();
    }
}
