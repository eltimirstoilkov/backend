using AutoMapper;
using Business.Interfaces.v1;
using Business.Models.v1.Responses;
using Microsoft.Extensions.Logging;
using Persistence.Entities.v1;
using Persistence.Interfaces.v1;

namespace Business.Implementations.v1;

public class VehicleInfoService : IVehicleInfoService
{
    private readonly IVehicleInfoRepository _infoRepository;
    private readonly ILogger<VehicleInfoService> _logger;
    private readonly IMapper _mapper;
    private readonly IValidationService _validationService;

    public VehicleInfoService(
        IVehicleInfoRepository infoRepository,
        ILogger<VehicleInfoService> logger,
        IMapper mapper,
        IValidationService validationService)
    {
        _logger = logger;
        _mapper = mapper;
        _infoRepository = infoRepository;
        _validationService = validationService;
    }

    public async Task<IList<VehicleInfoResponse>> GetAllAsync()
    {
        IList<VehicleInfo> vehicleEntities = await _infoRepository.GetAllAsync();
        IList<VehicleInfoResponse> responses = _mapper.Map<IList<VehicleInfoResponse>>(vehicleEntities);
        return responses;
    }

    public async Task<VehicleInfoResponse> GetByIdAsync(Guid id)
    {
        VehicleInfo? purpose = await _infoRepository.GetByIdAsync(id);
        if (purpose is null)
        {
            //ToDo fix exception and message
            _logger.LogError("No valid purpose was found with id {PurposeId}", id);
            throw new Exception();
        }

        var response = _mapper.Map<VehicleInfoResponse>(purpose);
        return response;
    }
    
}