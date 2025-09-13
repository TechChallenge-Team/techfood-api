using System;
using System.Collections.Generic;
using TechFood.Domain.Enums;

namespace TechFood.Application.Preparations.Dto;

public record DailyPreparationDto(
    Guid Id,
    Guid OrderId,
    int Number,
    decimal Amount,
    DateTime CreatedAt,
    DateTime? StartedAt,
    DateTime? ReadyAt,
    PreparationStatusType Status,
    List<DailyPreparationItemDto> Items);
