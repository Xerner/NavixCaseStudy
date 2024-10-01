using NavixCaseStudy.Common.Models;

namespace NavixCaseStudy.CaseStudyApiWrapper.DTOs;

public class ManufacturerDTO
{
    public int Mfr_ID { get; set; }
    public string Country { get; set; } = string.Empty;
    public string? Mfr_CommonName { get; set; } = null;
    public string Mfr_Name { get; set; } = string.Empty;
    public IEnumerable<VehicleTypeDTO> VehicleTypes { get; set; } = [];

    public Manufacturer ToCommonModel()
    {
        return new Manufacturer()
        {
            Id = Mfr_ID,
            ShortName = Mfr_CommonName,
            FullName = Mfr_Name,
            Country = Country
        };
    }
}
