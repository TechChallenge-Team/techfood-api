using System.Collections.Generic;
using MediatR;
using TechFood.Application.Orders.Dto;

namespace TechFood.Application.Orders.Queries.GetReadyOrders;

public class GetReadyOrdersQuery : IRequest<List<OrderDto>>;
