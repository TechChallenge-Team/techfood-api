using System.Threading.Tasks;
using TechFood.Application.Menu.Dto;

namespace TechFood.Application.Menu.Queries;

public interface IMenuQueryProvider
{
    Task<MenuDto> GetAsync();
}
