using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Common.Services.Interfaces;
using TechFood.Application.Orders.Dto;
using TechFood.Domain.Entities;
using TechFood.Domain.Repositories;

namespace TechFood.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler(
    IOrderRepository orderRepo,
    IProductRepository productRepo,
    ICustomerRepository customerRepo,
    IOrderNumberService orderNumberService,
    IImageUrlResolver imageUrlResolver
        ) : IRequestHandler<CreateOrderCommand, OrderDto>
{
    public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var products = await productRepo.GetAllAsync();

        var number = await orderNumberService.GetAsync();
        var customer = request.CustomerId != null ? await customerRepo.GetByIdAsync(request.CustomerId.Value) : null;
        var order = new Order(number, customer?.Id);

        var items = request.Items
            .Select(item =>
            {
                var product = products.First(p => p!.Id == item.ProductId)!;
                var orderItem = new OrderItem(product.Id, product.Price, item.Quantity);

                return (product, orderItem);
            })
            .ToList();

        foreach (var (_, item) in items)
        {
            order.AddItem(item);
        }

        await orderRepo.AddAsync(order);

        return new OrderDto(
            order.Id,
            order.Number,
            order.Amount,
            order.CreatedAt,
            customer != null ? new CustomerDto(customer.Id, customer.Name.FullName) : null,
            order.Status,
            items.ConvertAll(item =>
                new OrderItemDto(
                    item.orderItem.Id,
                    item.product.Name,
                    imageUrlResolver.BuildFilePath(nameof(Product).ToLower(), item.product.ImageFileName),
                    item.product.Price,
                    item.orderItem.Quantity
                )
            ));
    }
}
