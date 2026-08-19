using TravelPlanner.Api.Models;

namespace TravelPlanner.Api.Data;

public static class TravelSeedData
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (context.Destinations.Any())
            return;

        var destinations = new List<Destination>
        {
            new()
            {
                City = "Seoul",
                Country = "South Korea",
                CountryCode = "KR",
                Flag = "🇰🇷",
                Description = "A vibrant mix of palaces, cafés, shopping, food and modern Korean culture.",
                ImageUrl = "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c",
                MinDays = 3,
                MaxDays = 10
            },
            new()
            {
                City = "Jeju",
                Country = "South Korea",
                CountryCode = "KR",
                Flag = "🇰🇷",
                Description = "A volcanic island paradise with waterfalls, beaches, cliffs and beautiful nature.",
                ImageUrl = "https://images.unsplash.com/photo-1578637387939-43c525550085",
                MinDays = 3,
                MaxDays = 10
            },
            new()
            {
                City = "Busan",
                Country = "South Korea",
                CountryCode = "KR",
                Flag = "🇰🇷",
                Description = "A beautiful coastal city famous for beaches, seafood, markets and colourful villages.",
                ImageUrl = "https://images.unsplash.com/photo-1590253230532-a67f6bc61c9e",
                MinDays = 3,
                MaxDays = 10
            },
            new()
            {
                City = "Daejeon",
                Country = "South Korea",
                CountryCode = "KR",
                Flag = "🇰🇷",
                Description = "A relaxed Korean city known for science, parks, cafés and nearby nature.",
                ImageUrl = "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c",
                MinDays = 2,
                MaxDays = 7
            },
            new()
            {
                City = "Suwon",
                Country = "South Korea",
                CountryCode = "KR",
                Flag = "🇰🇷",
                Description = "A historic Korean city centered around the impressive Hwaseong Fortress.",
                ImageUrl = "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c",
                MinDays = 2,
                MaxDays = 5
            },
            new()
            {
                City = "Hong Kong",
                Country = "Hong Kong",
                CountryCode = "HK",
                Flag = "🇭🇰",
                Description = "A spectacular combination of skyscrapers, food, shopping, mountains and islands.",
                ImageUrl = "https://images.unsplash.com/photo-1536599018102-9f803c7f1f2b",
                MinDays = 3,
                MaxDays = 10
            },
            new()
            {
                City = "Taipei",
                Country = "Taiwan",
                CountryCode = "TW",
                Flag = "🇹🇼",
                Description = "Night markets, temples, cafés, mountains and amazing Taiwanese food.",
                ImageUrl = "https://images.unsplash.com/photo-1470004914212-05527e49370b",
                MinDays = 3,
                MaxDays = 10
            },
            new()
            {
                City = "Bangkok",
                Country = "Thailand",
                CountryCode = "TH",
                Flag = "🇹🇭",
                Description = "A lively city filled with temples, street food, markets, shopping and nightlife.",
                ImageUrl = "https://images.unsplash.com/photo-1508009603885-50cf7c579365",
                MinDays = 3,
                MaxDays = 10
            },
            new()
            {
                City = "Ho Chi Minh City",
                Country = "Vietnam",
                CountryCode = "VN",
                Flag = "🇻🇳",
                Description = "A lively city filled with street food, cafés, history and modern energy.",
                ImageUrl = "https://images.unsplash.com/photo-1583417319070-4a69db38a482",
                MinDays = 3,
                MaxDays = 10
            },
            new()
            {
                City = "Cebu",
                Country = "Philippines",
                CountryCode = "PH",
                Flag = "🇵🇭",
                Description = "Tropical beaches, islands, waterfalls and unforgettable adventures.",
                ImageUrl = "https://images.unsplash.com/photo-1518509562904-e7ef99cdcc86",
                MinDays = 3,
                MaxDays = 10
            },
            new()
            {
                City = "Bali",
                Country = "Indonesia",
                CountryCode = "ID",
                Flag = "🇮🇩",
                Description = "Rice terraces, beaches, temples, cafés and tropical island escapes.",
                ImageUrl = "https://images.unsplash.com/photo-1537996194471-e657df975ab4",
                MinDays = 4,
                MaxDays = 10
            },
            new()
            {
                City = "Batam",
                Country = "Indonesia",
                CountryCode = "ID",
                Flag = "🇮🇩",
                Description = "An easy island escape with resorts, seafood and relaxing coastal experiences.",
                ImageUrl = "https://images.unsplash.com/photo-1507525428034-b723cf961d3e",
                MinDays = 2,
                MaxDays = 7
            },
            new()
            {
                City = "Kuala Lumpur",
                Country = "Malaysia",
                CountryCode = "MY",
                Flag = "🇲🇾",
                Description = "A modern multicultural city famous for food, shopping and its iconic skyline.",
                ImageUrl = "https://images.unsplash.com/photo-1596422846543-75c6fc197f07",
                MinDays = 3,
                MaxDays = 10
            },
            new()
            {
                City = "Johor Bahru",
                Country = "Malaysia",
                CountryCode = "MY",
                Flag = "🇲🇾",
                Description = "A convenient Malaysian city with shopping, food and family-friendly attractions.",
                ImageUrl = "https://images.unsplash.com/photo-1596422846543-75c6fc197f07",
                MinDays = 2,
                MaxDays = 7
            },
            new()
            {
                City = "Malacca",
                Country = "Malaysia",
                CountryCode = "MY",
                Flag = "🇲🇾",
                Description = "A charming historic city filled with heritage buildings, cafés and local food.",
                ImageUrl = "https://images.unsplash.com/photo-1596422846543-75c6fc197f07",
                MinDays = 2,
                MaxDays = 7
            }
        };

        await context.Destinations.AddRangeAsync(destinations);
        await context.SaveChangesAsync();
    }
}