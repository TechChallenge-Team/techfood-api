using System;
using TechFood.Domain.Common.Interfaces;

namespace TechFood.Domain.Events.Order;

public record class OrderCancelledEvent(
    Guid Id,
    DateTime CancelledAt) : IDomainEvent;
