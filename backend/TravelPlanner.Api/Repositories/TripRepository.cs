using Microsoft.EntityFrameworkCore;
using TravelPlanner.Api.Data;
using TravelPlanner.Api.Interfaces;
using TravelPlanner.Api.Models;

namespace TravelPlanner.Api.Repositories;

public class TripRepository : ITripRepository
{
    private readonly ApplicationDbContext _context;

    public TripRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Trip>> GetAllAsync()
    {
        return await _context.Trips.ToListAsync();
    }

    public async Task<Trip?> GetByIdAsync(Guid id)
    {
        return await _context.Trips.FindAsync(id);
    }

    public async Task<Trip> CreateAsync(Trip trip)
    {
        _context.Trips.Add(trip);
        await _context.SaveChangesAsync();

        return trip;
    }
}