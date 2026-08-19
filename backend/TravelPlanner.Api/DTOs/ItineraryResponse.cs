namespace TravelPlanner.Api.DTOs;

public class ItineraryResponse
{
    public int DestinationId { get; set; }

    public string Destination { get; set; } = string.Empty;

    public int Days { get; set; }

    public List<ItineraryDayDto> Itinerary { get; set; } = new();
}

public class ItineraryDayDto
{
    public int Day { get; set; }

    public string Title { get; set; } = string.Empty;

    public List<ItineraryStopDto> Stops { get; set; } = new();
}

public class ItineraryStopDto
{
    public int AttractionId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Area { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public int VisitDurationMinutes { get; set; }

    public int StopOrder { get; set; }
}