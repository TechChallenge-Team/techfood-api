using System;
using TechFood.Shared.Domain.Interfaces;

namespace TechFood.Domain.Events.Preparation;

public record class PreparationReadyEvent(
    Guid Id,
    Guid OrderId,
    DateTime ReadyAt) : IDomainEvent;
