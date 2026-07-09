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

    public TripController(ITripRepository repository)
    {
        _repository = repository;
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
        var trip = new Trip
        {
            Destination = request.Destination,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Budget = request.Budget
        };

        await _repository.CreateAsync(trip);

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
}

