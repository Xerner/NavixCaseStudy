using NavixCaseStudy.CaseStudyApiWrapper.DTOs;
using NavixCaseStudy.Common.DTOs;

namespace NavixCaseStudy.CaseStudyApiWrapper.Interfaces;

public interface IManufacturerService
{
    Task<Dictionary<string, List<ManufacturerDTO>>?> GetByVehicleTypeAsync(ManufacturerFilterDTO? filterDTO);
}
