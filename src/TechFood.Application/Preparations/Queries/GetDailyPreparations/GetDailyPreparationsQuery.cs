using System.Collections.Generic;
using MediatR;
using TechFood.Application.Preparations.Dto;

namespace TechFood.Application.Preparations.Queries.GetDailyPreparations;

public record GetDailyPreparationsQuery : IRequest<List<DailyPreparationDto>>;
