using NavixCaseStudy.CaseStudyApiWrapper.DTOs;
using NavixCaseStudy.CaseStudyApiWrapper.Interfaces;
using NavixCaseStudy.Common.DTOs;
using NavixCaseStudy.Common.Models;

namespace NavixCaseStudy.CaseStudyApiWrapper.Services;

public class ManufacturerService(IManufacturerRepository manufacturerRepository) : IManufacturerService
{
    /// <summary>
    /// Assumed grouping by the manufacturer's primary vehicle type, also assuming the manufacturer only has one primary vehicle type.
    /// </summary>
    /// <returns>Manufacturers grouped by their primary vehicle type</returns>
    public async Task<IDictionary<string, ISet<Manufacturer>>> GetByVehicleTypeAsync(ManufacturerFilterDTO? filterDTO)
    {
        var manufacturerResults = await manufacturerRepository.GetAsync(filterDTO);
        var manufacturersByVehicleType = new Dictionary<string, HashSet<Manufacturer>>();
        if (manufacturerResults is null || manufacturerResults.Results is null)
        {
            return (IDictionary<string, ISet<Manufacturer>>)manufacturersByVehicleType;
        }
        // Group manufacturers by their vehicle type
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
                if (!manufacturersByVehicleType.ContainsKey(vehicleType.Name))
                {
                    manufacturersByVehicleType[vehicleType.Name] = [];
                }
                manufacturersByVehicleType[vehicleType.Name].Add(manufacturerDTO.ToCommonModel());
            }
        }
        return (IDictionary<string, ISet<Manufacturer>>)manufacturersByVehicleType;
    }
}
