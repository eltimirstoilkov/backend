namespace Business.Models.v1.Responses;

public class VehicleInfoResponse
{
    public int EngineCapacity { get; init; }

    public int VehicleAge { get; init; }

    public string Town { get; set; }

    public string Purpose { get; init; }
}