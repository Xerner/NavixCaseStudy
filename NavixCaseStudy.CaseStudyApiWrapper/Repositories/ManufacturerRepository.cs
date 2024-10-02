using System.Net.Http.Json;
using Microsoft.AspNetCore.WebUtilities;
using NavixCaseStudy.CaseStudyApiWrapper.DTOs.Abstract;
using NavixCaseStudy.CaseStudyApiWrapper.DTOs;
using NavixCaseStudy.Common.Repositories.Abstract;
using NavixCaseStudy.Common.DTOs;
using NavixCaseStudy.CaseStudyApiWrapper.Interfaces;

namespace NavixCaseStudy.Application.Repositories;

public class ManufacturerRepository(IHttpClientFactory httpClientFactory) 
    : HttpRepository("ManufacturerRepository", httpClientFactory), 
      IManufacturerRepository
{

    /// <summary>
    /// Fetches manufacturers information, including vehicle types, from the case study API
    /// </summary>
    public async Task<ResultsDTO<ManufacturerDTO, ManufacturerSearchCriteriaDTO?>?> GetAsync(ManufacturerFilterDTO? filterDTO = null)
    {
        var query = new Dictionary<string, string?>();
        if (filterDTO is not null)
        {
            // ?Mfr_ID=manufacturerId
            AddQueryParams(query, "ManufacturerID", filterDTO.ManufacturerIDs);
            // ?VehicleType=vehicleTypeName possibly appearing multiple times
            AddQueryParams(query, "VehicleType", filterDTO.VehicleTypeNames);
        }
        var uri = QueryHelpers.AddQueryString("https://navixrecruitingcasestudy.blob.core.windows.net/manufacturers/vehicle-manufacturers.json", query);
        var request = await _httpClient.GetAsync(uri);
        if (request is null)
        {
            return null;
        }
        // FIXME: this fails to deserialize the JSON response because there exists a manufacturer whos "Country" is equal to "1"
        var manufacturers = await request.Content.ReadFromJsonAsync<ResultsDTO<ManufacturerDTO, ManufacturerSearchCriteriaDTO?>>();
        if (manufacturers is null || manufacturers.Results == null)
        {
            return null;
        }
        return manufacturers;
    }
}
