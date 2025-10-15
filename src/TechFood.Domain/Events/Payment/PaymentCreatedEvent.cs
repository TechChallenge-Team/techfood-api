using System;
using TechFood.Domain.Enums;
using TechFood.Shared.Domain.Interfaces;

namespace TechFood.Domain.Events.Payment;

public record class PaymentCreatedEvent(
    Guid Id,
    Guid OrderId,
    DateTime CreatedAt,
    PaymentType PaymentType,
    decimal Amount) : IDomainEvent;
