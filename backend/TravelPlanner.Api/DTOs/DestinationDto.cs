namespace TravelPlanner.Api.DTOs;

public class DestinationDto
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
}