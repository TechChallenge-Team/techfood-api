using System;
using TechFood.Domain.Enums;
using TechFood.Shared.Domain.Interfaces;

namespace TechFood.Domain.Events.Payment;

public record class PaymentConfirmedEvent(
    Guid Id,
    Guid OrderId,
    DateTime PaidAt,
    PaymentType PaymentType,
    decimal Amount) : IDomainEvent;
