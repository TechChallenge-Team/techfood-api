using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Categories.Dto;
using TechFood.Application.Common.Resources;
using TechFood.Application.Common.Services.Interfaces;
using TechFood.Domain.Entities;
using TechFood.Domain.Repositories;

namespace TechFood.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler(
        ICategoryRepository repo,
        IImageUrlResolver imageUrl,
        IImageStorageService imageStore)
            : IRequestHandler<UpdateCategoryCommand, CategoryDto>
{
    public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await repo.GetByIdAsync(request.Id);

        if (category == null)
        {
            throw new Common.Exceptions.ApplicationException(Exceptions.Category_CategoryNotFound);
        }

        var imageFileName = category.ImageFileName;

        if (request.ImageFile != null)
        {
            imageFileName = imageUrl.CreateImageFileName(request.Name, request.ImageContentType!);

            await imageStore.SaveAsync(request.ImageFile,
                                       imageFileName,
                                       nameof(Category));

            await imageStore.DeleteAsync(category.ImageFileName, nameof(Category));
        }

        category.UpdateAsync(request.Name, imageFileName);

        return new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name,
            ImageUrl = imageUrl.BuildFilePath(nameof(Categories).ToLower(), imageFileName)
        };
    }
}
