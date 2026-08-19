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

    public DbSet<Destination> Destinations => Set<Destination>();

    public DbSet<Attraction> Attractions => Set<Attraction>();

    public DbSet<TravelPlanner.Api.Models.Route> Routes
        => Set<TravelPlanner.Api.Models.Route>();

    public DbSet<RouteAttraction> RouteAttractions
        => Set<RouteAttraction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<RouteAttraction>()
            .HasKey(x => new { x.RouteId, x.AttractionId });

        modelBuilder.Entity<RouteAttraction>()
            .HasOne(x => x.Route)
            .WithMany(x => x.RouteAttractions)
            .HasForeignKey(x => x.RouteId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RouteAttraction>()
            .HasOne(x => x.Attraction)
            .WithMany()
            .HasForeignKey(x => x.AttractionId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Destination>()
            .HasMany(x => x.Attractions)
            .WithOne(x => x.Destination)
            .HasForeignKey(x => x.DestinationId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Destination>()
            .HasMany(x => x.Routes)
            .WithOne(x => x.Destination)
            .HasForeignKey(x => x.DestinationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}