using System;
using System.Threading.Tasks;
using TechFood.Domain.Entities;

namespace TechFood.Domain.Repositories;

public interface IPreparationRepository
{
    Task<Guid> AddAsync(Preparation preparation);

    Task<Preparation?> GetByIdAsync(Guid id);

    Task<Preparation?> GetByOrderIdAsync(Guid orderId);
}
