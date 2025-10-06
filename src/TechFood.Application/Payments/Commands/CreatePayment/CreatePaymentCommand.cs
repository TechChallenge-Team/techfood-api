using System;
using MediatR;
using TechFood.Application.Payments.Dto;
using TechFood.Domain.Enums;

namespace TechFood.Application.Payments.Commands.CreatePayment;

public record CreatePaymentCommand(Guid OrderId, PaymentType Type) : IRequest<PaymentDto>;
