using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechFood.Application.Categories.Commands.CreateCategory;
using TechFood.Application.Categories.Commands.DeleteCategory;
using TechFood.Application.Categories.Commands.UpdateCategory;
using TechFood.Application.Categories.Queries.GetCategory;
using TechFood.Application.Categories.Queries.ListCategories;
using TechFood.Contracts.Categories;

namespace TechFood.Api.Controllers;

[ApiController()]
[Route("v1/[controller]")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> ListAsync()
    {
        var query = new ListCategoriesQuery();

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        var query = new GetCategoryQuery(id);

        var result = await _mediator.Send(query);

        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCategoryRequest request)
    {
        var imageFile = request.File;
        var command = new CreateCategoryCommand(
            request.Name,
            imageFile.OpenReadStream(),
            imageFile.ContentType);

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateCategoryRequest request)
    {
        var imageFile = request.File;
        var command = new UpdateCategoryCommand(
            id,
            request.Name,
            imageFile?.OpenReadStream(),
            imageFile?.ContentType);

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var command = new DeleteCategoryCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }
}
