using System;
using TechFood.Shared.Domain.Events;

namespace TechFood.Domain.Events.Preparation;

public record class PreparationReadyEvent(
    Guid Id,
    Guid OrderId,
    DateTime ReadyAt) : IDomainEvent;
