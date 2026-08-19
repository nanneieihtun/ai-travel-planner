namespace TravelPlanner.Api.Models;

public class Attraction
{
    public int Id { get; set; }

    public int DestinationId { get; set; }

    public Destination Destination { get; set; } = null!;

    public string Name { get; set; } = string.Empty;

    public string Area { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public int Priority { get; set; }

    public int VisitDurationMinutes { get; set; }

    public string BestFor { get; set; } = string.Empty;

    public double Latitude { get; set; }

    public double Longitude { get; set; }
}