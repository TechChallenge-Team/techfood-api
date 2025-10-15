using System;
using TechFood.Shared.Domain.Interfaces;

namespace TechFood.Domain.Events.Order;

public record class OrderCancelledEvent(
    Guid Id,
    DateTime CancelledAt) : IDomainEvent;
