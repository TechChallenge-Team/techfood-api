using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Preparations.Dto;

namespace TechFood.Application.Preparations.Queries.GetPreparation;

public class GetPreparationQueryHandler(IPreparationQueryProvider queries) : IRequestHandler<GetPreparationQuery, PreparationDto?>
{
    public Task<PreparationDto?> Handle(GetPreparationQuery request, CancellationToken cancellationToken)
        => queries.GetByIdAsync(request.Id);
}
