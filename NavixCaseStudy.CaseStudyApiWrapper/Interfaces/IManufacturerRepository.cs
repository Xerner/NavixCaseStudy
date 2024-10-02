using NavixCaseStudy.CaseStudyApiWrapper.DTOs.Abstract;
using NavixCaseStudy.CaseStudyApiWrapper.DTOs;
using NavixCaseStudy.Common.DTOs;

namespace NavixCaseStudy.CaseStudyApiWrapper.Interfaces;

public interface IManufacturerRepository
{
    Task<ResultsDTO<ManufacturerDTO, ManufacturerSearchCriteriaDTO?>?> GetAsync(ManufacturerFilterDTO? filterDTO = null);
}