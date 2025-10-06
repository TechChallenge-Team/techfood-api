using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Orders.Dto;

namespace TechFood.Application.Orders.Queries.GetOrders;

public class GetOrdersQueryHandler(IOrderQueryProvider queries) : IRequestHandler<GetOrdersQuery, List<OrderDto>>
{
    public Task<List<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        => queries.GetOrdersAsync();
}
