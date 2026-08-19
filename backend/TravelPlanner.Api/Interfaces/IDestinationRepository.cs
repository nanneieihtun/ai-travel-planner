using TravelPlanner.Api.Models;

namespace TravelPlanner.Api.Interfaces;

public interface IDestinationRepository
{
    Task<List<Destination>> GetDestinationsAsync(
        string? country = null,
        int? days = null);

    Task<Destination?> GetDestinationByIdAsync(int id);
    Task<Destination?> GetDestinationWithAttractionsAsync(int id);
}