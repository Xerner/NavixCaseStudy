using Microsoft.AspNetCore.Mvc;
using NavixCaseStudy.CaseStudyApiWrapper.DTOs;
using NavixCaseStudy.CaseStudyApiWrapper.Services;
using NavixCaseStudy.Common.DTOs;
using NavixCaseStudy.Common.Models;
using Swashbuckle.Swagger.Annotations;

namespace NavixCaseStudy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ManufacturerController(ManufacturerService _manufacturerService) : ControllerBase
{
    /// <summary>
    /// Fetches manufacturers and groups them by what vehicle types they produce.
    /// </summary>
    /// <param name="filterDTO">The filter to restrict the search to</param>
    /// <returns>The manufacturers in buckets labeled by vehicle type names</returns>
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, "Manufacturers by vehicle type were retrieved successfully.", typeof(ManufacturersByVehicleTypeDTO))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No manufacturers and/or vehicle types were found")]
    public async Task<ActionResult<Dictionary<string, List<ManufacturerDTO>>>> GetByVehicleType([FromQuery] ManufacturerFilterDTO filterDTO)
    {
        var manufacturersByVehicleType = await _manufacturerService.GetByVehicleTypeAsync(filterDTO);
        if (manufacturersByVehicleType is null)
        {
            return NotFound();
        }
        return Ok(manufacturersByVehicleType);
    }
}
