using System.ComponentModel.DataAnnotations;

namespace TravelPlanner.Api.DTOs;

public class UpdateTripRequest
{
    [Required]
    [MaxLength(100)]
    public string Destination { get; set; } = string.Empty;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    [Range(0, 1000000)]
    public decimal Budget { get; set; }
}