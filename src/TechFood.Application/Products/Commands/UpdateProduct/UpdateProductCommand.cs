using System;
using System.IO;
using MediatR;
using TechFood.Application.Products.Dto;

namespace TechFood.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    string Description,
    Guid CategoryId,
    decimal Price,
    Stream? ImageFile,
    string? ImageContentType
    ) : IRequest<ProductDto>;
