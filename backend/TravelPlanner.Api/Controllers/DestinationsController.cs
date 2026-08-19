using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Api.Interfaces;

namespace TravelPlanner.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DestinationsController : ControllerBase
{
    private readonly IDestinationService _service;

    public DestinationsController(IDestinationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetDestinations(
        [FromQuery] string? country = null,
        [FromQuery] int? days = null)
    {
        var destinations =
            await _service.GetDestinationsAsync(country, days);

        return Ok(destinations);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetDestination(int id)
    {
        var destination =
            await _service.GetDestinationByIdAsync(id);

        if (destination == null)
        {
            return NotFound();
        }

        return Ok(destination);
    }

    [HttpGet("{id:int}/itinerary")]
    public async Task<IActionResult> GetItinerary(
     int id,
     [FromQuery] int days)
    {
        if (days < 1 || days > 10)
            return BadRequest(
                "Days must be between 1 and 10.");

        var itinerary =
            await _service.GenerateItineraryAsync(id, days);

        if (itinerary == null)
            return NotFound();

        return Ok(itinerary);
    }
}