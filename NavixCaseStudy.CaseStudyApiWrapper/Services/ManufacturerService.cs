using NavixCaseStudy.CaseStudyApiWrapper.DTOs;
using NavixCaseStudy.CaseStudyApiWrapper.Interfaces;
using NavixCaseStudy.Common.DTOs;

namespace NavixCaseStudy.CaseStudyApiWrapper.Services;

public class ManufacturerService(IManufacturerRepository manufacturerRepository) : IManufacturerService
{
    /// <summary>
    /// Assumed grouping by the manufacturer's primary vehicle type, also assuming the manufacturer only has one primary vehicle type.
    /// </summary>
    /// <returns>Manufacturers grouped by their primary vehicle type</returns>
    public async Task<Dictionary<string, List<ManufacturerDTO>>?> GetByVehicleTypeAsync(ManufacturerFilterDTO? filterDTO)
    {
        var manufacturerResults = await manufacturerRepository.GetAsync(filterDTO);
        if (manufacturerResults is null || manufacturerResults.Results is null)
        {
            return null;
        }
        var vehicleTypeNameToManufacturers = new Dictionary<string, List<ManufacturerDTO>>();
        foreach (var manufacturerDTO in manufacturerResults.Results)
        {
            if (manufacturerDTO is null)
            {
                continue;
            }
            foreach (var vehicleType in manufacturerDTO.VehicleTypes)
            {
                if (vehicleType is null)
                {
                    continue;
                }
                if (!vehicleTypeNameToManufacturers.ContainsKey(vehicleType.Name))
                {
                    vehicleTypeNameToManufacturers[vehicleType.Name] = [];
                }
                vehicleTypeNameToManufacturers[vehicleType.Name].Add(manufacturerDTO);
            }
        }
        return vehicleTypeNameToManufacturers;
    }
}
