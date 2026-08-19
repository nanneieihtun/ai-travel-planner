using TravelPlanner.Api.Models;

namespace TravelPlanner.Api.Interfaces;

public interface ITripRepository
{
    Task<List<Trip>> GetAllAsync();

    Task<Trip?> GetByIdAsync(Guid id);

    Task<Trip> CreateAsync(Trip trip);
    Task<Trip?> UpdateAsync(Guid id, Trip trip);
    Task<bool> DeleteAsync(Guid id);
    

}