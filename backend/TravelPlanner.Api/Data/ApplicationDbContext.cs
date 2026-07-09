using Microsoft.EntityFrameworkCore;
using TravelPlanner.Api.Models;

namespace TravelPlanner.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Trip> Trips => Set<Trip>();
}