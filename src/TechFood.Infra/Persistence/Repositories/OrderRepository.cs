using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechFood.Domain.Entities;
using TechFood.Domain.Repositories;
using TechFood.Infra.Persistence.Contexts;

namespace TechFood.Infra.Persistence.Repositories;

internal class OrderRepository(TechFoodContext dbContext) : IOrderRepository
{
    private readonly DbSet<Order> _orders = dbContext.Orders;

    public async Task<Guid> AddAsync(Order order)
    {
        var entry = await _orders.AddAsync(order);

        return entry.Entity.Id;
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        var t = await _orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id);

        return t;
    }
}
