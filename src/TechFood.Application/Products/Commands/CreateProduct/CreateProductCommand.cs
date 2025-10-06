using System;
using System.IO;
using MediatR;
using TechFood.Application.Products.Dto;

namespace TechFood.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    string Description,
    Guid CategoryId,
    Stream ImageFile,
    string ImageContentType,
    decimal Price) : IRequest<ProductDto>;
