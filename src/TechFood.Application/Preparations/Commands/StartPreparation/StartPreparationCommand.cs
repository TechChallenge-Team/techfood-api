using System;
using MediatR;

namespace TechFood.Application.Preparations.Commands.StartPreparation;

public record StartPreparationCommand(Guid Id) : IRequest<Unit>;
