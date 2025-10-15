using System;
using TechFood.Shared.Domain.Interfaces;

namespace TechFood.Domain.Events.Preparation;

public record class PreparationCreatedEvent(
    Guid Id,
    Guid OrderId,
    DateTime CreatedAt) : IDomainEvent;
