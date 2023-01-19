using Persistence.Entities.v1;
using System.Threading.Tasks;

namespace Vehicles.Data.Interfaces.v1
{
    public interface ITownRepository
    {
        Task<Town> GetByIdAsync(Guid id);

        Task<bool> IsExistingTownAsync(Guid id);

        Task<Town> GetAllAsync();
    }
}
