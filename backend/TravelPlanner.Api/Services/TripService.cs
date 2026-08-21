using TravelPlanner.Api.DTOs;
using TravelPlanner.Api.Interfaces;
using TravelPlanner.Api.Models;
using Microsoft.EntityFrameworkCore;
using TravelPlanner.Api.Data;

namespace TravelPlanner.Api.Services;

public class TripService : ITripService
{
    private readonly ITripRepository _repository;
    private readonly ApplicationDbContext _context;
    public TripService(
      ITripRepository repository,
      ApplicationDbContext context)
    {
        _repository = repository;
        _context = context;
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

    if (request.Days < 1 || request.Days > 10)
        throw new ArgumentException("Trip must be between 1 and 10 days.");

    var trip = new Trip
    {
        Destination = request.Destination,
        StartDate = request.StartDate,
        EndDate = request.EndDate,
        Budget = request.Budget,
        Days = request.Days
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

    public async Task<ItineraryResponse?> GenerateItineraryAsync(
    int destinationId,
    int days)
    {
        if (days < 1 || days > 10)
            throw new ArgumentException(
                "Trip duration must be between 1 and 10 days.");

        var destination = await _context.Destinations
            .Include(d => d.Routes)
                .ThenInclude(r => r.RouteAttractions)
                    .ThenInclude(ra => ra.Attraction)
            .FirstOrDefaultAsync(d => d.Id == destinationId);

        if (destination == null)
            return null;

        var routes = destination.Routes
            .Where(r =>
                r.RecommendedMinDays <= days &&
                r.RecommendedMaxDays >= days)
            .OrderBy(r => r.RecommendedMinDays)
            .ToList();

        // If there aren't enough exact matches,
        // use routes that are closest to the requested duration.
        if (!routes.Any())
        {
            routes = destination.Routes
                .OrderBy(r =>
                    Math.Abs(r.RecommendedMinDays - days))
                .ToList();
        }

        var selectedStops = routes
            .SelectMany(r => r.RouteAttractions
                .OrderBy(ra => ra.StopOrder))
            .Select(ra => ra.Attraction)
            .GroupBy(a => a.Id)
            .Select(g => g.First())
            .ToList();

        if (!selectedStops.Any())
        {
            // Fallback to attractions directly.
            selectedStops = await _context.Attractions
                .Where(a => a.DestinationId == destinationId)
                .OrderByDescending(a => a.Priority)
                .ToListAsync();
        }

        // Don't show more than 4 major stops per day.
        var maxStopsPerDay = 4;

        var itinerary = new List<ItineraryDayDto>();

        for (int day = 1; day <= days; day++)
        {
            itinerary.Add(new ItineraryDayDto
            {
                Day = day,
                Title = $"Day {day}",
                Stops = new List<ItineraryStopDto>()
            });
        }

        for (int i = 0; i < selectedStops.Count; i++)
        {
            var dayIndex = i / maxStopsPerDay;

            if (dayIndex >= days)
                break;

            var attraction = selectedStops[i];

            itinerary[dayIndex].Stops.Add(
                new ItineraryStopDto
                {
                    AttractionId = attraction.Id,
                    Name = attraction.Name,
                    Area = attraction.Area,
                    Category = attraction.Category,
                    Description = attraction.Description,
                    ImageUrl = attraction.ImageUrl,
                    VisitDurationMinutes =
                        attraction.VisitDurationMinutes,
                    StopOrder =
                        itinerary[dayIndex].Stops.Count + 1
                });
        }

        // Remove empty days.
        itinerary = itinerary
            .Where(day => day.Stops.Any())
            .ToList();

        // Re-number the days after removing empty days.
        for (int i = 0; i < itinerary.Count; i++)
        {
            itinerary[i].Day = i + 1;
            itinerary[i].Title =
                $"Day {i + 1}";
        }

        return new ItineraryResponse
        {
            DestinationId = destination.Id,
            Destination = destination.City,
            Days = days,
            Itinerary = itinerary
        };
    }
}