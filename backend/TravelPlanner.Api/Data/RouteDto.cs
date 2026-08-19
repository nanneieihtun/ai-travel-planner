namespace TravelPlanner.Api.DTOs;

public class RouteDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public int RecommendedMinDays { get; set; }

    public int RecommendedMaxDays { get; set; }

    public List<RouteStopDto> Stops { get; set; } = new();
}

public class RouteStopDto
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