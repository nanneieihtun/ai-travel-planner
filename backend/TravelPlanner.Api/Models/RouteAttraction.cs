namespace TravelPlanner.Api.Models;

public class RouteAttraction
{
    public int RouteId { get; set; }

    public Route Route { get; set; } = null!;

    public int AttractionId { get; set; }

    public Attraction Attraction { get; set; } = null!;

    public int DayOrder { get; set; }

    public int StopOrder { get; set; }
}