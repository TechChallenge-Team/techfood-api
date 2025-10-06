using System;
using MediatR;

namespace TechFood.Application.Preparations.Commands.CompletePreparation;

public record CompletePreparationCommand(Guid Id) : IRequest<Unit>;
