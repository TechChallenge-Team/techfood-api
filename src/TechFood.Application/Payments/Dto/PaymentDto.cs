using System;
using TechFood.Domain.Enums;

namespace TechFood.Application.Payments.Dto;

public record PaymentDto(Guid Id, Guid OrderId, DateTime CreatedAt, DateTime? PaidAt, PaymentType Type, PaymentStatusType Status, decimal Amount, string? QrCodeData = null);
