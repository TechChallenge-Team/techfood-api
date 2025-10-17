using System;
using TechFood.Shared.Domain.Events;

namespace TechFood.Domain.Events.Order;

public record class OrderCreatedEvent(
    Guid Id,
    Guid? CustomerId,
    DateTime CreatedAt) : IDomainEvent;
