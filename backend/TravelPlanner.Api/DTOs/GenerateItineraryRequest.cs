namespace TravelPlanner.Api.DTOs;

public class GenerateItineraryRequest
{
    public string Destination { get; set; } = string.Empty;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public decimal Budget { get; set; }

    public string TravelStyle { get; set; } = string.Empty;

    public int NumberOfTravelers { get; set; }

    public string Preferences { get; set; } = string.Empty;
}