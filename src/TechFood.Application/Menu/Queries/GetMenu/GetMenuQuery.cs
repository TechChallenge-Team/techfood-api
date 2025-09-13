using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechFood.Application.Menu.Dto;

namespace TechFood.Application.Menu.Queries.GetMenu
{
    public class GetMenuQuery : IRequest<MenuDto>
    {
        public class Handler(IMenuQueryProvider queries) : IRequestHandler<GetMenuQuery, MenuDto>
        {
            public Task<MenuDto> Handle(GetMenuQuery request, CancellationToken cancellationToken)
                => queries.GetAsync();
        }
    }
}
