using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechFood.Application.Common.Services.Interfaces;
using TechFood.Application.Preparations.Dto;
using TechFood.Application.Preparations.Queries;
using TechFood.Domain.Entities;
using TechFood.Domain.Enums;
using TechFood.Infra.Persistence.Contexts;

namespace TechFood.Infra.Persistence.Queries;

internal class PreparationQueryProvider(
    IImageUrlResolver imageUrlResolver,
    TechFoodContext techFoodContext) : IPreparationQueryProvider
{
    public async Task<PreparationDto?> GetByIdAsync(Guid id)
    {
        return await techFoodContext.Preparations
            .AsNoTracking()
            .Where(order => order.Id == id)
            .Select(preparation => new PreparationDto(
                preparation.Id,
                preparation.OrderId,
                preparation.CreatedAt,
                preparation.StartedAt,
                preparation.ReadyAt,
                preparation.Status
            ))
            .FirstOrDefaultAsync();
    }

    public async Task<List<DailyPreparationDto>> GetDailyPreparationsAsync()
    {
        var status = new PreparationStatusType[]
        {
            PreparationStatusType.Pending,
            PreparationStatusType.Started
        };

        var products = await techFoodContext.Products.AsNoTracking().ToListAsync();

        var result = await techFoodContext.Orders
            .AsNoTracking()
            .Include(order => order.Items)
            .Join(
                techFoodContext.Preparations,
                order => order.Id,
                preparation => preparation.OrderId,
                (order, preparation) => new
                {
                    Order = order,
                    Preparation = preparation
                }
            )
            .Where(query => status.Contains(query.Preparation.Status))
            .OrderBy(query => query.Preparation.CreatedAt)
            .ToListAsync();

        return result.Select(data => new DailyPreparationDto(
            data.Preparation.Id,
            data.Order.Id,
            data.Order.Number,
            data.Order.Amount,
            data.Preparation.CreatedAt,
            data.Preparation.StartedAt,
            data.Preparation.ReadyAt,
            data.Preparation.Status,
            data.Order.Items.Select(item =>
            {
                var product = products.FirstOrDefault(p => p.Id == item.ProductId);
                return new DailyPreparationItemDto(
                    item.Id,
                    product!.Name,
                    item.Quantity,
                    imageUrlResolver.BuildFilePath(nameof(Product).ToLower(), product.ImageFileName));
            }).ToList()))
            .ToList();
    }

    public async Task<List<TrackingPreparationDto>> GetTrackingItemsAsync()
    {
        var orderStatus = new OrderStatusType[]
        {
            OrderStatusType.Received,
            OrderStatusType.InPreparation,
            OrderStatusType.Ready
        };
        var preparationStatus = new PreparationStatusType[]
        {
            PreparationStatusType.Pending,
            PreparationStatusType.Started,
            PreparationStatusType.Ready
        };

        var result = await techFoodContext.Orders
            .AsNoTracking()
            .Join(
                techFoodContext.Preparations,
                order => order.Id,
                preparation => preparation.OrderId,
                (order, preparation) => new
                {
                    Order = order,
                    Preparation = preparation
                }
            )
            .Where(query =>
                orderStatus.Contains(query.Order.Status) &&
                preparationStatus.Contains(query.Preparation.Status))
            .ToListAsync();

        return result.ConvertAll(data => new TrackingPreparationDto(
            data.Preparation.Id,
            data.Order.Id,
            data.Order.Number,
            data.Preparation.Status
            ));
    }
}
