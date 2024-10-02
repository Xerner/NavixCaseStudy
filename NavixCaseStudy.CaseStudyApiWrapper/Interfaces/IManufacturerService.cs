using NavixCaseStudy.CaseStudyApiWrapper.DTOs;
using NavixCaseStudy.Common.DTOs;
using NavixCaseStudy.Common.Models;

namespace NavixCaseStudy.CaseStudyApiWrapper.Interfaces;

public interface IManufacturerService
{
    Task<IDictionary<string, ISet<Manufacturer>>> GetByVehicleTypeAsync(ManufacturerFilterDTO? filterDTO);
}
