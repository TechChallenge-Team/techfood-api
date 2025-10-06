using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Preparations.Dto;

namespace TechFood.Application.Preparations.Queries.GetDailyPreparations;

public class GetDailyPreparationsQueryHandler(IPreparationQueryProvider queries) : IRequestHandler<GetDailyPreparationsQuery, List<DailyPreparationDto>>
{
    public Task<List<DailyPreparationDto>> Handle(GetDailyPreparationsQuery request, CancellationToken cancellationToken)
        => queries.GetDailyPreparationsAsync();
}
