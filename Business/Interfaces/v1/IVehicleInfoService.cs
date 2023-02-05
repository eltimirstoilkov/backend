using Business.Models.v1.Responses;

namespace Business.Interfaces.v1;

public interface IVehicleInfoService
{
    Task<IList<VehicleInfoResponse>> GetAllAsync();

    Task<VehicleInfoResponse> GetByIdAsync(Guid id);
}