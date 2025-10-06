using System;
using System.IO;
using MediatR;
using TechFood.Application.Categories.Dto;

namespace TechFood.Application.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(
    Guid Id,
    string Name,
    Stream? ImageFile,
    string? ImageContentType) : IRequest<CategoryDto>;
