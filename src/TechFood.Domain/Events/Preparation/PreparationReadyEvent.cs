using System;
using TechFood.Domain.Common.Interfaces;

namespace TechFood.Domain.Events.Preparation;

public record class PreparationReadyEvent(
    Guid Id,
    Guid OrderId,
    DateTime ReadyAt) : IDomainEvent;
