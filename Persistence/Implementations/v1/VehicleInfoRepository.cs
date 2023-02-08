using Microsoft.EntityFrameworkCore;
using Persistence.Context.v1;
using Persistence.Entities.v1;
using Persistence.Interfaces.v1;

namespace Persistence.Implementations.v1;

public class VehicleInfoRepository : IVehicleInfoRepository
{
    private readonly VehicleContext _dbContext;

    public VehicleInfoRepository(VehicleContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(VehicleInfo entity)
    {
        _dbContext.Add(entity);
    }

    public async Task<IList<VehicleInfo>> GetAllAsync()
    {
        return await _dbContext.VehicleInfos
            .Include(x => x.VehicleType)
            .Include(x => x.Municipality)
            .Include(x => x.VehiclePurpose)
            .Include(x => x.TariffType)
            .Take(20)
            .ToListAsync();
    }

    public async Task<VehicleInfo?> GetByIdAsync(Guid id)
    {
        VehicleInfo? info =  await _dbContext.VehicleInfos
            .Include(x => x.VehicleType)
            .Include(x => x.Municipality)
            .Include(x => x.VehiclePurpose)
            .Include(x => x.TariffType)
            .FirstOrDefaultAsync(x => x.Id == id);

        return info;
    }
    
    public void Delete(VehicleInfo entity)
    {
        _dbContext.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}