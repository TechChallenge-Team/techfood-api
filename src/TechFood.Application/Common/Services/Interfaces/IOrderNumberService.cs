using System.Threading.Tasks;

namespace TechFood.Application.Common.Services.Interfaces;

public interface IOrderNumberService
{
    Task<int> GetAsync();
}
