using TravelPlanner.Api.Interfaces;
using TravelPlanner.Api.Models;
using TravelPlanner.Api.DTOs;

namespace TravelPlanner.Api.Services;

public class DestinationService : IDestinationService
{
    private readonly IDestinationRepository _repository;

    public DestinationService(IDestinationRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Destination>> GetDestinationsAsync(
        string? country = null,
        int? days = null)
    {
        return await _repository.GetDestinationsAsync(country, days);
    }

    public async Task<Destination?> GetDestinationByIdAsync(int id)
    {
        return await _repository.GetDestinationByIdAsync(id);
    }
    public async Task<ItineraryResponse?> GenerateItineraryAsync(
    int destinationId,
    int days)
    {
        if (days < 1 || days > 10)
            throw new ArgumentException(
                "Trip duration must be between 1 and 10 days.");

        var destination =
            await _repository.GetDestinationWithAttractionsAsync(destinationId);

        if (destination == null)
            return null;

        var attractions = destination.Attractions
            .OrderByDescending(x => x.Priority)
            .ToList();

        if (!attractions.Any())
        {
            return new ItineraryResponse
            {
                DestinationId = destination.Id,
                Destination = destination.City,
                Days = days
            };
        }

        var itinerary = new ItineraryResponse
        {
            DestinationId = destination.Id,
            Destination = destination.City,
            Days = days
        };

        var attractionsPerDay =
            Math.Max(2, (int)Math.Ceiling(
                attractions.Count / (double)days));

        for (int day = 1; day <= days; day++)
        {
            var dayAttractions = attractions
                .Skip((day - 1) * attractionsPerDay)
                .Take(attractionsPerDay)
                .ToList();

            if (!dayAttractions.Any())
                break;

            itinerary.Itinerary.Add(
                new ItineraryDayDto
                {
                    Day = day,
                    Title = $"Day {day} — {GetDayTitle(day)}",
                    Stops = dayAttractions
                        .Select((attraction, index) =>
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
                                StopOrder = index + 1
                            })
                        .ToList()
                });
        }

        return itinerary;
    }

    private static string GetDayTitle(int day)
    {
        return day switch
        {
            1 => "Start Exploring",
            2 => "Discover More",
            3 => "Culture & Local Life",
            4 => "Hidden Gems",
            5 => "Food & Experiences",
            6 => "Neighbourhoods",
            7 => "Relax & Explore",
            8 => "More Adventures",
            9 => "Local Experiences",
            10 => "Final Day",
            _ => "Explore"
        };
    }
}