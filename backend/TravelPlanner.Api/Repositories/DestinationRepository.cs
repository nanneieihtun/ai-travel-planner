using Microsoft.EntityFrameworkCore;
using TravelPlanner.Api.Data;
using TravelPlanner.Api.Interfaces;
using TravelPlanner.Api.Models;

namespace TravelPlanner.Api.Repositories;

public class DestinationRepository : IDestinationRepository
{
    private readonly ApplicationDbContext _context;

    public DestinationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Destination>> GetDestinationsAsync(
        string? country = null,
        int? days = null)
    {
        var query = _context.Destinations
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(country))
        {
            query = query.Where(x =>
                x.Country.ToLower() == country.ToLower());
        }

        if (days.HasValue)
        {
            query = query.Where(x =>
                x.MinDays <= days.Value &&
                x.MaxDays >= days.Value);
        }

        return await query
            .OrderBy(x => x.Country)
            .ThenBy(x => x.City)
            .ToListAsync();
    }

    public async Task<Destination?> GetDestinationByIdAsync(int id)
    {
        return await _context.Destinations
            .AsNoTracking()
            .Include(x => x.Attractions)
            .Include(x => x.Routes)
                .ThenInclude(x => x.RouteAttractions)
                .ThenInclude(x => x.Attraction)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<Destination?> GetDestinationWithAttractionsAsync(int id)
{
    return await _context.Destinations
        .AsNoTracking()
        .Include(x => x.Attractions)
        .FirstOrDefaultAsync(x => x.Id == id);
}
}