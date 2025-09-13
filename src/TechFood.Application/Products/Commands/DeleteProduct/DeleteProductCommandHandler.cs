using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Common.Resources;
using TechFood.Application.Common.Services.Interfaces;
using TechFood.Domain.Entities;
using TechFood.Domain.Repositories;

namespace TechFood.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler(IProductRepository repo, IImageStorageService imageStorage) : IRequestHandler<DeleteProductCommand, Unit>
{
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await repo.GetByIdAsync(request.Id);
        if (product == null)
        {
            throw new Common.Exceptions.ApplicationException(Exceptions.Product_ProductNotFound);
        }

        await imageStorage.DeleteAsync(product.ImageFileName, nameof(Product));

        await repo.DeleteAsync(product);

        return Unit.Value;
    }
}
