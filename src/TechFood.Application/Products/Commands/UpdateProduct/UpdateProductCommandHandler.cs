using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Common.Resources;
using TechFood.Application.Common.Services.Interfaces;
using TechFood.Application.Products.Dto;
using TechFood.Domain.Entities;
using TechFood.Domain.Repositories;

namespace TechFood.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler(
    IProductRepository productRepository,
    ICategoryRepository categoryRepository,
    IImageUrlResolver imageUrl,
    IImageStorageService imageStore)
        : IRequestHandler<UpdateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id);
        if (product is null)
        {
            throw new Common.Exceptions.ApplicationException(Exceptions.Product_ProductNotFound);
        }

        var category = await categoryRepository.GetByIdAsync(request.CategoryId);
        if (category is null)
        {
            throw new Common.Exceptions.ApplicationException(Exceptions.Product_CaregoryNotFound);
        }

        var imageFileName = product.ImageFileName;

        if (request.ImageFile != null)
        {
            imageFileName = imageUrl.CreateImageFileName(request.Name, request.ImageContentType!);

            await imageStore.SaveAsync(request.ImageFile,
                                       imageFileName,
                                       nameof(Product));

            await imageStore.DeleteAsync(product.ImageFileName, nameof(Product));
        }

        product!.Update(
            request.Name,
            request.Description,
            imageFileName,
            request.Price,
            category.Id);

        return new ProductDto(
           product.Id,
           product.Name,
           product.Description,
           product.CategoryId,
           product.OutOfStock,
           imageUrl.BuildFilePath(nameof(Product).ToLower(), product.ImageFileName),
           product.Price
       );
    }
}
