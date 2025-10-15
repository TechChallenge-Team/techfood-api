using System;
using TechFood.Domain.Enums;
using TechFood.Shared.Domain.Interfaces;

namespace TechFood.Domain.Events.Payment;

public record class PaymentRefusedEvent(
    Guid Id,
    Guid OrderId,
    DateTime RefusedAt,
    PaymentType Type,
    decimal Amount) : IDomainEvent;
