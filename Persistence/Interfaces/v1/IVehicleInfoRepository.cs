using Persistence.Entities.v1;

namespace Persistence.Interfaces.v1;

public interface IVehicleInfoRepository
{
    void Add(VehicleInfo entity);

    Task<IList<VehicleInfo>> GetAllAsync();


    Task<VehicleInfo?> GetByIdAsync(Guid id);

    void Delete(VehicleInfo entity);

    Task SaveChangesAsync();
}