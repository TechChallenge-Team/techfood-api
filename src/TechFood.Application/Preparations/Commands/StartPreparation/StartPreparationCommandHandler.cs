using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Common.Resources;
using TechFood.Domain.Repositories;

namespace TechFood.Application.Preparations.Commands.StartPreparation;

public class StartPreparationCommandHandler(IPreparationRepository repo) : IRequestHandler<StartPreparationCommand, Unit>
{
    public async Task<Unit> Handle(StartPreparationCommand request, CancellationToken cancellationToken)
    {
        var preparation = await repo.GetByIdAsync(request.Id);
        if (preparation == null)
        {
            throw new Common.Exceptions.ApplicationException(Exceptions.Preparation_PreparationNotFound);
        }

        preparation.Start();

        return Unit.Value;
    }
}
