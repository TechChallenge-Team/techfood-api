using System;
using MediatR;
using TechFood.Application.Categories.Dto;

namespace TechFood.Application.Categories.Queries.GetCategory;

public record GetCategoryQuery(Guid Id) : IRequest<CategoryDto?>;
