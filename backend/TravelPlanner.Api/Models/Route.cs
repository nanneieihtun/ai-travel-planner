namespace TravelPlanner.Api.Models;

public class Route
{
    public int Id { get; set; }

    public int DestinationId { get; set; }

    public Destination Destination { get; set; } = null!;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public int RecommendedMinDays { get; set; }

    public int RecommendedMaxDays { get; set; }

    public ICollection<RouteAttraction> RouteAttractions { get; set; }
        = new List<RouteAttraction>();
}