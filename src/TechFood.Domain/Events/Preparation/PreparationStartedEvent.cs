using System;
using TechFood.Shared.Domain.Events;

namespace TechFood.Domain.Events.Preparation;

public record class PreparationStartedEvent(
    Guid Id,
    Guid OrderId,
    DateTime StartedAt) : IDomainEvent;
