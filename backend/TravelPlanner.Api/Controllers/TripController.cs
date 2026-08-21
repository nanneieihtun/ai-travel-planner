using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Api.DTOs;
using TravelPlanner.Api.Interfaces;
using TravelPlanner.Api.Models;

namespace TravelPlanner.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripController : ControllerBase
{
    private readonly ITripRepository _repository;
    private readonly ITripService _tripService;

    public TripController(ITripRepository repository, ITripService tripService)
    {
        _repository = repository;
        _tripService = tripService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrips()
    {
        var trips = await _repository.GetAllAsync();
        return Ok(trips);
    }

[HttpPost]
public async Task<IActionResult> CreateTrip(CreateTripRequest request)
{
    var trip = await _tripService.CreateAsync(request);

    return Ok(trip);
}

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTrip(Guid id)
    {
        var trip = await _repository.GetByIdAsync(id);
        if (trip == null)
        {
            return NotFound();
        }
        return Ok(trip);
    }
    [HttpPut("{id}")]
public async Task<IActionResult> UpdateTrip(Guid id, UpdateTripRequest request)
{
    var trip = await _tripService.UpdateAsync(id, request);

    if (trip == null)
        return NotFound();

    return Ok(trip);
}

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrip(Guid id)
    {
        var success = await _tripService.DeleteAsync(id);

        if (!success)
            return NotFound();

        return NoContent();
    }
}

