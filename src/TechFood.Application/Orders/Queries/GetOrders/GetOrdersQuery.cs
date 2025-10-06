using System.Collections.Generic;
using MediatR;
using TechFood.Application.Orders.Dto;

namespace TechFood.Application.Orders.Queries.GetOrders;

public record GetOrdersQuery : IRequest<List<OrderDto>>;
