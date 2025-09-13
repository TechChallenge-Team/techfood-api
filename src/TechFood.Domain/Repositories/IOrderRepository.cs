using System;
using System.Threading.Tasks;
using TechFood.Domain.Entities;

namespace TechFood.Domain.Repositories;

public interface IOrderRepository
{
    Task<Guid> AddAsync(Order order);

    Task<Order?> GetByIdAsync(Guid id);
}
