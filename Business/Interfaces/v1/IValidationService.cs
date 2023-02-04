namespace Business.Interfaces.v1;

public interface IValidationService
{
    Task ExecuteValidationAsync(int cityId, int tariffId, int typeId, int purposeId);

    Task ExistingTownAsync(int id);
             
    Task ExistingVehicleTarriffAsync(int id);
             
    Task ExistingVehicleTyepAsync(int id);
             
    Task ExistingPurposeTypeAsync(int id);
}