using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechFood.Application.Common.Services.Interfaces;
using TechFood.Application.Orders.Dto;
using TechFood.Application.Orders.Queries;
using TechFood.Domain.Entities;
using TechFood.Domain.Enums;
using TechFood.Infra.Persistence.Contexts;

namespace TechFood.Infra.Persistence.Queries;

internal class OrderQueryProvider(
    IImageUrlResolver imageUrlResolver,
    TechFoodContext techFoodContext
        ) : IOrderQueryProvider
{
    public async Task<List<OrderDto>> GetOrdersAsync()
    {
        var products = await techFoodContext.Products.ToListAsync();

        var result = await techFoodContext.Orders
            .AsNoTracking()
            .Include(order => order.Items)
            .OrderBy(order => order.CreatedAt)
            .Join(
                techFoodContext.Customers,
                order => order.CustomerId,
                customer => customer.Id,
                (order, customer) => new
                {
                    Order = order,
                    Customer = customer
                }
            )
            .ToListAsync();

        return result
            .Select(data => new OrderDto(
                data.Order.Id,
                data.Order.Number,
                data.Order.Amount,
                data.Order.CreatedAt,
                data.Customer != null ? new CustomerDto(data.Customer.Id, data.Customer.Name.FullName) : null,
                data.Order.Status,
                data.Order.Items.Select(item =>
                {
                    var product = products.FirstOrDefault(p => p.Id == item.ProductId);

                    return new OrderItemDto(
                        item.Id,
                        product!.Name,
                        imageUrlResolver.BuildFilePath(nameof(Product).ToLower(), product.ImageFileName),
                        item.UnitPrice, item.Quantity);
                }).ToList()))
            .ToList();
    }

    public async Task<List<OrderDto>> GetReadyOrdersAsync()
    {
        var products = await techFoodContext.Products.ToListAsync();

        var result = await techFoodContext.Orders
            .AsNoTracking()
            .Include(order => order.Items)
            .Where(order => order.Status == OrderStatusType.Ready)
            .OrderBy(order => order.CreatedAt)
            .Join(
                techFoodContext.Customers,
                order => order.CustomerId,
                customer => customer.Id,
                (order, customer) => new
                {
                    Order = order,
                    Customer = customer
                }
            )
            .ToListAsync();

        return result
             .Select(data => new OrderDto(
                 data.Order.Id,
                 data.Order.Number,
                 data.Order.Amount,
                 data.Order.CreatedAt,
                 data.Customer != null ? new CustomerDto(data.Customer.Id, data.Customer.Name.FullName) : null,
                 data.Order.Status,
                 data.Order.Items.Select(item =>
                 {
                     var product = products.FirstOrDefault(p => p.Id == item.ProductId);

                     return new OrderItemDto(
                         item.Id,
                         product!.Name,
                         imageUrlResolver.BuildFilePath(nameof(Product).ToLower(), product.ImageFileName),
                         item.UnitPrice, item.Quantity);
                 }).ToList()))
             .ToList();
    }
}
