using System;
using MediatR;

namespace TechFood.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(Guid Id) : IRequest<Unit>;
