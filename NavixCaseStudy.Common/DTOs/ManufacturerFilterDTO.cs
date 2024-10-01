namespace NavixCaseStudy.Common.DTOs;

public class ManufacturerFilterDTO
{
    public int? ManufacturerId { get; set; } = null;
    public List<string>? VehicleTypeNames { get; set; } = null;
}
