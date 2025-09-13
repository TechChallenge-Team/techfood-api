using System.Collections.Generic;
using MediatR;
using TechFood.Application.Preparations.Dto;

namespace TechFood.Application.Preparations.Queries.GetTrackingPreparations;

public record GetTrackingPreparationsQuery : IRequest<List<TrackingPreparationDto>>;
