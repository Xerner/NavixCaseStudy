using NavixCaseStudy.Common.Models;

namespace NavixCaseStudy.Common.DTOs;

// possibly just replace this with IGrouping<string, Manufacturer>, but not sure if that would stringify nicely
public class ManufacturersByVehicleTypeDTO
{
    public string? VehicleType { get; set; } = null;
    public IEnumerable<Manufacturer> Manufacturers { get; set; } = [];
}
