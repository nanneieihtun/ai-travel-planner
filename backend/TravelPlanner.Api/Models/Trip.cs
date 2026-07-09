namespace TravelPlanner.Api.Models;

public class Trip
{
    public Guid Id { get; set; }

    public string Destination { get; set; } = string.Empty;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public decimal Budget { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}