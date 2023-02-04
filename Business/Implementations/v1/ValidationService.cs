using Business.Interfaces.v1;
using Microsoft.EntityFrameworkCore;
using Persistence.Context.v1;
using Persistence.Entities.v1;
using static Business.Constants;

namespace Business.Implementations.v1;

public class ValidationService : IValidationService
{
    private readonly VehicleContext _dbContext;

    public ValidationService(VehicleContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ExecuteValidationAsync(int cityId, int tariffId, int typeId, int purposeId)
    {
        await ExistingTownAsync(cityId);
        await ExistingVehicleTarriffAsync(tariffId);
        await ExistingPurposeTypeAsync(typeId);
        await ExistingPurposeTypeAsync(purposeId);
    }

    public async Task ExistingAgeGroup(int? ownerAge)
    {
        if (ownerAge is null)
        {
                
        }
    }

    public async Task ExistingTownAsync(int id)
    {
        Municipality? result = await _dbContext.Municipalities.FirstOrDefaultAsync(x => x.Id == id)
                               ?? throw new ArgumentException(string.Format(NotFoundErrorMessage, "Municipality", id));
    }

    public async Task ExistingVehicleTarriffAsync(int id)
    {
        VehicleTariffType? result = await _dbContext.VehicleTariffTypes.FirstOrDefaultAsync(x => x.Id == id)
                                    ?? throw new ArgumentException(string.Format(NotFoundErrorMessage, "Tariff Type", id));
    }

    public async Task ExistingVehicleTyepAsync(int id)
    {
        VehicleType? result = await _dbContext.VehicleTypes.FirstOrDefaultAsync(x => x.Id == id)
                              ?? throw new ArgumentException(string.Format(NotFoundErrorMessage, "Vehicle Type", id));
    }

    public async Task ExistingPurposeTypeAsync(int id)
    {
        VehiclePurpose? result = await _dbContext.VehiclePurposes.FirstOrDefaultAsync(x => x.Id == id)
                          ?? throw new ArgumentException(string.Format(NotFoundErrorMessage, "Purpose", id));
    }
}