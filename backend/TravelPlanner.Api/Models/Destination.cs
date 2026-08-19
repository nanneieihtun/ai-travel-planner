namespace TravelPlanner.Api.Models;

public class Destination
{
    public int Id { get; set; }

    public string City { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public string CountryCode { get; set; } = string.Empty;

    public string Flag { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public int MinDays { get; set; }

    public int MaxDays { get; set; }

    public ICollection<Attraction> Attractions { get; set; } = new List<Attraction>();

    public ICollection<Route> Routes { get; set; } = new List<Route>();
}