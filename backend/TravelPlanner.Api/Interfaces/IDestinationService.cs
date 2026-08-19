using TravelPlanner.Api.Models;
using TravelPlanner.Api.DTOs;
namespace TravelPlanner.Api.Interfaces;

public interface IDestinationService
{
    Task<List<Destination>> GetDestinationsAsync(
        string? country = null,
        int? days = null);

    Task<Destination?> GetDestinationByIdAsync(int id);
  Task<ItineraryResponse?> GenerateItineraryAsync(
        int destinationId,
        int days);
}