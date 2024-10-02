namespace NavixCaseStudy.Common.DTOs;

public class ManufacturerFilterDTO
{
    public IEnumerable<int>? ManufacturerIDs { get; set; } = null;
    public IEnumerable<string>? VehicleTypeNames { get; set; } = null;
}
