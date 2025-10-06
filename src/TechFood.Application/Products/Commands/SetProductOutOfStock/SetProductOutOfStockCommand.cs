using System;
using MediatR;
using TechFood.Application.Products.Dto;

namespace TechFood.Application.Products.Commands.SetProductOutOfStock;

public record SetProductOutOfStockCommand(Guid Id, bool OutOfStock) : IRequest<ProductDto>;
