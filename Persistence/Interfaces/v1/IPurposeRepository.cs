using Persistence.Entities.v1;

namespace Persistence.Interfaces.v1;

public interface IPurposeRepository
{
    VehiclePurpose Add(VehiclePurpose vehiclePurpose);

    void Delete(VehiclePurpose vehiclePurpose);

    Task<IList<VehiclePurpose>> GetAllAsync();

    Task<VehiclePurpose?> GetByIdAsync(int id);

    Task<bool> IsExistingAsync(string description);

    Task<int> SaveChangesAsync();
}