namespace TravelPlanner.Api.DTOs;

using System.ComponentModel.DataAnnotations;

public class CreateTripRequest
{
    [Required]
    [MaxLength(100)]
    public string Destination { get; set; } = string.Empty;


    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    [Range(0, 100000)]
    public decimal Budget { get; set; }
    
    [Range(1, 10)]
    public int Days { get; set; }
}