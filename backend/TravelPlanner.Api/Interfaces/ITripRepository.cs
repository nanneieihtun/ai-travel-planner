using TravelPlanner.Api.Models;

namespace TravelPlanner.Api.Interfaces;

public interface ITripRepository
{
    Task<List<Trip>> GetAllAsync();

    Task<Trip?> GetByIdAsync(Guid id);

    Task<Trip> CreateAsync(Trip trip);
}