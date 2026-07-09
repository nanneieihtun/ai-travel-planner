using TravelPlanner.Api.DTOs;
using TravelPlanner.Api.Models;

namespace TravelPlanner.Api.Interfaces;

public interface ITripService
{
    Task<List<Trip>> GetAllAsync();
    Task<Trip> CreateAsync(CreateTripRequest request);
    Task<Trip> GetByIdAsync(Guid id);
}