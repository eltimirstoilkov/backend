using Business.Models.v1;

namespace Business.Interfaces.v1
{
    public interface IVehicleService
    {
        Task<VehicleResponse> GetByIdAsync(Guid id);
        
        Task<VehicleResponse> ThrowException();

        Task<IEnumerable<VehicleResponse>> GetAllAsync();

        Task<VehicleResponse> CreateAsync(VehicleRequest model);

        Task<IEnumerable<VehicleResponse>> GetVehiclesInRangeAsync(int min, int max);


        Task<UpdateResponse> UpdateAsync(Guid id, VehicleRequest model);

        Task<IEnumerable<VehicleResponse>> GetByTownAsync(string townName);

        Task<DeleteRespons> DeleteAsync(Guid id);
    }
}
