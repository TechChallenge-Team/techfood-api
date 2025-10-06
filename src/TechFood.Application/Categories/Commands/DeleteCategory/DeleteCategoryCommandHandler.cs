using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Common.Resources;
using TechFood.Domain.Repositories;

namespace TechFood.Application.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler(ICategoryRepository repo) : IRequestHandler<DeleteCategoryCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await repo.GetByIdAsync(request.Id);
        if (category == null)
        {
            throw new Common.Exceptions.ApplicationException(Exceptions.Category_CategoryNotFound);
        }

        await repo.DeleteAsync(category);

        return Unit.Value;
    }
}

