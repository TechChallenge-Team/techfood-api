using System.Threading.Tasks;
using System.Threading;
using MediatR;
using TechFood.Application.Categories.Dto;

namespace TechFood.Application.Categories.Queries.GetCategory;

public class GetCategoryQueryHandler(ICategoryQueryProvider queries) : IRequestHandler<GetCategoryQuery, CategoryDto?>
{
    public Task<CategoryDto?> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        => queries.GetByIdAsync(request.Id);
}
