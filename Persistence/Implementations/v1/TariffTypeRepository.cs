using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Context.v1;
using Persistence.Entities.v1;
using Persistence.Interfaces.v1;

namespace Persistence.Implementations.v1;

public class TariffTypeRepository : ITariffTypeRepository
{
    private readonly VehicleContext _dbContext;

    public TariffTypeRepository(VehicleContext dbContext)
    {
        _dbContext = dbContext;
    }

    public VehicleTariffType Add(VehicleTariffType tariff)
    {
        EntityEntry<VehicleTariffType> newTariff = _dbContext.VehicleTariffTypes
            .Add(tariff);
        return newTariff.Entity;
    }

    public void Delete(VehicleTariffType tariff)
    {
        _dbContext.VehicleTariffTypes.Remove(tariff);
    }

    public async Task<IList<VehicleTariffType>> GetAllAsync()
    {
        List<VehicleTariffType> all = await _dbContext.VehicleTariffTypes.ToListAsync();
        return all;
    }

    public Task<VehicleTariffType?> GetByIdAsync(int id)
    {
        var tariff = _dbContext.VehicleTariffTypes
            .FirstOrDefaultAsync(x => x.Id == id);
        return tariff;
    }

    public Task<bool> IsExistingAsync(string description)
    {
        var result = _dbContext.VehicleTariffTypes
            .AnyAsync(x => x.Description == description);
        return result;
    }

    public async Task<int> SaveChangesAsync()
    {
        var result = await _dbContext.SaveChangesAsync();
        return result;
    }

}