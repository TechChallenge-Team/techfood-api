using System;
using TechFood.Shared.Domain.Interfaces;

namespace TechFood.Domain.Events.Order;

public record class OrderCreatedEvent(
    Guid Id,
    Guid? CustomerId,
    DateTime CreatedAt) : IDomainEvent;
