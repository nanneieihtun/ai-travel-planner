using TravelPlanner.Api.DTOs;
using TravelPlanner.Api.Interfaces;
using TravelPlanner.Api.Models;

namespace TravelPlanner.Api.Services;

public class TripService : ITripService
{
    private readonly ITripRepository _repository;

    public TripService(ITripRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Trip>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Trip> CreateAsync(CreateTripRequest request)
    {
        if (request.EndDate < request.StartDate)
            throw new ArgumentException("End date must be after start date.");

        if (request.Budget < 0)
            throw new ArgumentException("Budget cannot be negative.");

        var trip = new Trip
        {
            Destination = request.Destination,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Budget = request.Budget
        };

        return await _repository.CreateAsync(trip);
    }   

    public async Task<Trip> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Trip?> UpdateAsync(Guid id, UpdateTripRequest request)
    {
        if (request.EndDate < request.StartDate)
            throw new ArgumentException("End date must be after start date.");

        if (request.Budget < 0)
            throw new ArgumentException("Budget cannot be negative.");

        var updatedTrip = new Trip
        {
            Destination = request.Destination,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Budget = request.Budget
        };

        return await _repository.UpdateAsync(id, updatedTrip);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }
}