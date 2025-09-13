using System.Collections.Generic;
using MediatR;
using TechFood.Application.Categories.Dto;

namespace TechFood.Application.Categories.Queries.ListCategories;

public record ListCategoriesQuery : IRequest<List<CategoryDto>>;
