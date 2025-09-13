using System;

namespace TechFood.Application.Preparations.Dto;

public record DailyPreparationItemDto(Guid Id, string Name, int Quantity, string ImageUrl);
