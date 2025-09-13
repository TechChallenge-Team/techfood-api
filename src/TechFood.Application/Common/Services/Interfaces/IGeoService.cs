using System.Threading.Tasks;
using TechFood.Application.Common.Data;

namespace TechFood.Application.Common.Services.Interfaces;

public interface IGeoService
{
    Task<Location> GetLocationAsync(Coordinates coordinates);
}
