using System;
using MediatR;

namespace TechFood.Application.Orders.Commands.DeliverOrder;

public record DeliverOrderCommand(Guid Id) : IRequest<Unit>;
