using TravelPlanner.Api.Models;

namespace TravelPlanner.Api.Data;

public static class TravelRouteSeedData
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (context.Routes.Any())
            return;

        var seoul = context.Destinations
            .FirstOrDefault(x => x.City == "Seoul");

        if (seoul == null)
            return;

        var attractions = context.Attractions
            .Where(x => x.DestinationId == seoul.Id)
            .ToList();

        var routes = new List<TravelPlanner.Api.Models.Route>
        {
            CreateRoute(
                seoul,
                "Historic Seoul",
                "Palaces, traditional neighbourhoods and Korean culture.",
                "Culture",
                1,
                3,
                attractions,
                "Gyeongbokgung Palace",
                "Bukchon Hanok Village",
                "Insadong",
                "Changdeokgung Palace"
            ),

            CreateRoute(
                seoul,
                "Central Seoul",
                "Markets, shopping and Seoul's iconic city views.",
                "City",
                1,
                4,
                attractions,
                "Gwangjang Market",
                "Myeongdong",
                "N Seoul Tower"
            ),

            CreateRoute(
                seoul,
                "Hongdae & West Seoul",
                "Youth culture, cafés, shopping and nightlife.",
                "Lifestyle",
                2,
                5,
                attractions,
                "Hongdae"
            ),

            CreateRoute(
                seoul,
                "Seongsu & Seoul Forest",
                "Trendy cafés, pop-ups and a relaxing urban park.",
                "Lifestyle",
                3,
                7,
                attractions,
                "Seongsu",
                "Seoul Forest"
            ),

            CreateRoute(
                seoul,
                "Gangnam",
                "Modern Seoul, shopping, architecture and entertainment.",
                "Modern",
                4,
                10,
                attractions,
                "COEX Mall",
                "Gangnam"
            )
        };

        await context.Routes.AddRangeAsync(routes);
        await context.SaveChangesAsync();

    }

    private static TravelPlanner.Api.Models.Route CreateRoute(
        Destination destination,
        string name,
        string description,
        string category,
        int minDays,
        int maxDays,
        List<Attraction> attractions,
        params string[] attractionNames)
    {
        var route = new TravelPlanner.Api.Models.Route
        {
            DestinationId = destination.Id,
            Name = name,
            Description = description,
            Category = category,
            RecommendedMinDays = minDays,
            RecommendedMaxDays = maxDays
        };

        int stopOrder = 1;

        foreach (var attractionName in attractionNames)
        {
            var attraction = attractions
                .FirstOrDefault(x =>
                    x.Name == attractionName);

            if (attraction == null)
                continue;

            route.RouteAttractions.Add(
                new RouteAttraction
                {
                    Route = route,
                    Attraction = attraction,
                    DayOrder = 1,
                    StopOrder = stopOrder++
                });
        }

        return route;
    }
}