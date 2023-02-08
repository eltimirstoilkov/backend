using Microsoft.EntityFrameworkCore;
using Persistence.Context.v1;
using Persistence.Entities.v1;
using Persistence.Interfaces.v1;

namespace Persistence.Implementations.v1;

public class PurposeRepository : IPurposeRepository
{
    private readonly VehicleContext _dbContext;

    public PurposeRepository(VehicleContext dbContext)
    {
        _dbContext = dbContext;
    }

    public VehiclePurpose Add(VehiclePurpose vehiclePurpose)
    {
        return _dbContext.VehiclePurposes.Add(vehiclePurpose).Entity;
    }

    public void Delete(VehiclePurpose vehiclePurpose)
    {
        _dbContext.VehiclePurposes.Remove(vehiclePurpose);
    }

    public async Task<IList<VehiclePurpose>> GetAllAsync()
    {
        List<VehiclePurpose> purposes = await _dbContext.VehiclePurposes.ToListAsync();
        return purposes;
    }

    public async Task<VehiclePurpose?> GetByIdAsync(int id)
    {
        VehiclePurpose? purpose = await _dbContext.VehiclePurposes
            .FirstOrDefaultAsync(x => x.Id == id);
        return purpose;
    }

    public async Task<bool> IsExistingAsync(string description)
    {
        bool result = await _dbContext.VehiclePurposes
            .AnyAsync(x => x.Description == description);
        return result;
    }

    public async Task<int> SaveChangesAsync()
    {
        int result = await _dbContext.SaveChangesAsync();
        return result;
    }

}