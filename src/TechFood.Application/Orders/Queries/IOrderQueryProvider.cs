using System.Collections.Generic;
using System.Threading.Tasks;
using TechFood.Application.Orders.Dto;

namespace TechFood.Application.Orders.Queries;

public interface IOrderQueryProvider
{
    Task<List<OrderDto>> GetOrdersAsync();

    Task<List<OrderDto>> GetReadyOrdersAsync();
}
