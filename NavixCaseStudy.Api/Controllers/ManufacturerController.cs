using Microsoft.AspNetCore.Mvc;
using NavixCaseStudy.CaseStudyApiWrapper.DTOs;
using NavixCaseStudy.CaseStudyApiWrapper.Interfaces;
using NavixCaseStudy.Common.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace NavixCaseStudy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ManufacturerController(IManufacturerService _manufacturerService) : ControllerBase
{
    /// <summary>
    /// Fetches manufacturers and groups them by what vehicle types they produce.
    /// </summary>
    /// <param name="filterDTO">The filter to restrict the search to</param>
    /// <returns>The manufacturers in buckets labeled by vehicle type names</returns>
    [SwaggerResponse(StatusCodes.Status200OK, "Manufacturers by vehicle type were retrieved successfully.", typeof(ManufacturersByVehicleTypeDTO))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No manufacturers and/or vehicle types were found")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ManufacturersByVehicleTypeDTO>>> GetByVehicleType([FromQuery] ManufacturerFilterDTO? filterDTO)
    {
        var manufacturersByVehicleType = await _manufacturerService.GetByVehicleTypeAsync(filterDTO);
        if (manufacturersByVehicleType is null)
        {
            return NotFound();
        }
        var manufacturersByVehicleTypeDTOs = manufacturersByVehicleType.ToList().Select(bucket => new ManufacturersByVehicleTypeDTO()
        {
            VehicleType = bucket.Key,
            Manufacturers = bucket.Value.ToList()
        });
        return Ok(manufacturersByVehicleTypeDTOs);
    }
}
