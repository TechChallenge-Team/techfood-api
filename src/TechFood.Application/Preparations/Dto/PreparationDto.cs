using System;
using TechFood.Domain.Enums;

namespace TechFood.Application.Preparations.Dto;

public record PreparationDto(
    Guid Id,
    Guid OrderId,
    DateTime CreatedAt,
    DateTime? StartedAt,
    DateTime? ReadyAt,
    PreparationStatusType Status);
