using System.ComponentModel.DataAnnotations;
using TechFood.Domain.Enums;

namespace TechFood.Contracts.Payments;

public record CreatePaymentRequest(
    [Required] Guid OrderId,
    [Required] PaymentType Type);
