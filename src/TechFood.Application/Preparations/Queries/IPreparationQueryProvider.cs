using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechFood.Application.Preparations.Dto;

namespace TechFood.Application.Preparations.Queries;

public interface IPreparationQueryProvider
{
    Task<PreparationDto?> GetByIdAsync(Guid id);

    Task<List<DailyPreparationDto>> GetDailyPreparationsAsync();

    Task<List<TrackingPreparationDto>> GetTrackingItemsAsync();
}
