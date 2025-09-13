using System;
using System.Collections.Generic;
using MediatR;
using TechFood.Application.Orders.Dto;

namespace TechFood.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(Guid? CustomerId, List<CreateOrderCommand.Item> Items) : IRequest<OrderDto>
{
    public record Item(Guid ProductId, int Quantity);
}
