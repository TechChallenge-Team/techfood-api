using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechFood.Application.Categories.Dto;

namespace TechFood.Application.Categories.Queries;

public interface ICategoryQueryProvider
{
    Task<List<CategoryDto>> GetAllAsync();

    Task<CategoryDto?> GetByIdAsync(Guid id);
}
