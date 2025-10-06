using System.IO;
using MediatR;
using TechFood.Application.Categories.Dto;

namespace TechFood.Application.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(
    string Name,
    Stream ImageFile,
    string ImageContentType) : IRequest<CategoryDto>;
