using System;
using MediatR;
using TechFood.Application.Preparations.Dto;

namespace TechFood.Application.Preparations.Queries.GetPreparation;

public record GetPreparationQuery(Guid Id) : IRequest<PreparationDto?>;
