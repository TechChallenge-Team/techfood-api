using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Common.Resources;
using TechFood.Application.Common.Services.Interfaces;
using TechFood.Application.Products.Dto;
using TechFood.Domain.Entities;
using TechFood.Domain.Repositories;

namespace TechFood.Application.Products.Commands.SetProductOutOfStock;

public class SetProductOutOfStockCommandHandler(IProductRepository repo, IImageUrlResolver imageUrl) : IRequestHandler<SetProductOutOfStockCommand, ProductDto>
{
    public async Task<ProductDto> Handle(SetProductOutOfStockCommand request, CancellationToken cancellationToken)
    {
        var product = await repo.GetByIdAsync(request.Id);
        if (product is null)
        {
            throw new Common.Exceptions.ApplicationException(Exceptions.Product_ProductNotFound);
        }

        product.SetOutOfStock(request.OutOfStock);

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
