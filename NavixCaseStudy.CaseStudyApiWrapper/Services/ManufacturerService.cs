using NavixCaseStudy.Application.Repositories;
using NavixCaseStudy.CaseStudyApiWrapper.DTOs;
using NavixCaseStudy.Common.DTOs;
using NavixCaseStudy.Common.Models;
using System.Xml;

namespace NavixCaseStudy.CaseStudyApiWrapper.Services;

public class ManufacturerService(ManufacturerRepository manufacturerRepository)
{
    /// <summary>
    /// Assumed grouping by the manufacturer's primary vehicle type, also assuming the manufacturer only has one primary vehicle type.
    /// </summary>
    /// <returns>Manufacturers grouped by their primary vehicle type</returns>
    public async Task<Dictionary<string, List<ManufacturerDTO>>?> GetByVehicleTypeAsync(ManufacturerFilterDTO filterDTO)
    {
        var manufacturerResults = await manufacturerRepository.GetAsync(filterDTO);
        if (manufacturerResults is null || manufacturerResults.Results is null)
        {
            return null;
        }
        var vehicleTypeNameToManufacturers = new Dictionary<string, List<ManufacturerDTO>>();
        foreach (var manufacturerDTO in manufacturerResults.Results)
        {
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
