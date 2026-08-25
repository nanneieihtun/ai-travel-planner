using TravelPlanner.Api.Models;

namespace TravelPlanner.Api.Data;

public static class TravelAttractionSeedData
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (context.Attractions.Any())
            return;

        var destinations = context.Destinations.ToList();

        var attractions = new List<Attraction>();

        AddSeoul(attractions, destinations);
        AddJeju(attractions, destinations);
        AddBusan(attractions, destinations);
        AddDaejeon(attractions, destinations);
        AddSuwon(attractions, destinations);
        AddHongKong(attractions, destinations);
        AddTaipei(attractions, destinations);
        AddBangkok(attractions, destinations);
        AddHoChiMinh(attractions, destinations);
        AddCebu(attractions, destinations);
        AddBali(attractions, destinations);
        AddBatam(attractions, destinations);
        AddKualaLumpur(attractions, destinations);
        AddJohorBahru(attractions, destinations);
        AddMalacca(attractions, destinations);

        await context.Attractions.AddRangeAsync(attractions);
        await context.SaveChangesAsync();
    }

    private static Destination? Find(
        List<Destination> destinations,
        string city)
    {
        return destinations.FirstOrDefault(x => x.City == city);
    }

    private static void Add(
        List<Attraction> list,
        Destination? destination,
        string name,
        string area,
        string category,
        string description,
        int priority,
        int duration,
        string imageUrl)
    {
        if (destination == null)
            return;

        list.Add(new Attraction
        {
            DestinationId = destination.Id,
            Name = name,
            Area = area,
            Category = category,
            Description = description,
            ImageUrl = imageUrl,
            Priority = priority,
            VisitDurationMinutes = duration,
            BestFor = category,
            Latitude = 0,
            Longitude = 0
        });
    }

    private static void AddSeoul(
        List<Attraction> list,
        List<Destination> destinations)
    {
        var d = Find(destinations, "Seoul");

        Add(list, d, "Gyeongbokgung Palace", "Jongno",
            "Culture",
            "Seoul's grandest Joseon palace and one of the city's essential historic sights.",
            10, 120,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");

        Add(list, d, "Bukchon Hanok Village", "Jongno",
            "Culture",
            "A beautiful traditional neighbourhood filled with preserved hanok houses and small lanes.",
            10, 90,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");

        Add(list, d, "Insadong", "Jongno",
            "Shopping",
            "Traditional shops, tea houses, galleries and Korean souvenirs.",
            8, 90,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");

        Add(list, d, "Changdeokgung Palace", "Jongno",
            "Culture",
            "A UNESCO-listed palace famous for its beautiful architecture and Secret Garden.",
            9, 120,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");

        Add(list, d, "Gwangjang Market", "Jongno",
            "Food",
            "One of Seoul's best places to experience traditional Korean street food.",
            9, 120,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");

        Add(list, d, "Myeongdong", "Jung-gu",
            "Shopping",
            "A lively shopping district famous for Korean beauty products, fashion and street food.",
            10, 150,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");

        Add(list, d, "N Seoul Tower", "Yongsan",
            "Viewpoint",
            "An iconic Seoul viewpoint offering panoramic city views.",
            10, 120,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");

        Add(list, d, "Hongdae", "Mapo",
            "Nightlife",
            "A youthful neighbourhood filled with cafés, shopping, street performances and nightlife.",
            9, 180,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");

        Add(list, d, "Seongsu", "Seongdong",
            "Cafe",
            "A trendy neighbourhood known for converted warehouses, cafés, fashion and pop-ups.",
            9, 180,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");

        Add(list, d, "Seoul Forest", "Seongdong",
            "Nature",
            "A large urban park perfect for a slower afternoon.",
            7, 120,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");

        Add(list, d, "COEX Mall", "Gangnam",
            "Shopping",
            "A huge shopping and entertainment complex featuring the famous Starfield Library.",
            8, 150,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");

        Add(list, d, "Gangnam", "Gangnam",
            "Modern",
            "Modern Seoul shopping, cafés, restaurants and nightlife.",
            8, 150,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");
    }

    private static void AddJeju(
        List<Attraction> list,
        List<Destination> destinations)
    {
        var d = Find(destinations, "Jeju");

        Add(list, d, "Seongsan Ilchulbong", "Seongsan",
            "Nature",
            "A dramatic volcanic crater and one of Jeju's most iconic landscapes.",
            10, 150,
            "https://images.unsplash.com/photo-1578637387939-43c525550085");

        Add(list, d, "Hallasan National Park", "Jeju",
            "Nature",
            "The volcanic mountain at the heart of Jeju Island.",
            10, 240,
            "https://images.unsplash.com/photo-1578637387939-43c525550085");

        Add(list, d, "Manjanggul Cave", "Gujwa",
            "Nature",
            "A spectacular lava tube showcasing Jeju's volcanic geology.",
            8, 120,
            "https://images.unsplash.com/photo-1578637387939-43c525550085");

        Add(list, d, "Jeju Stone Park", "Jocheon",
            "Culture",
            "A peaceful park celebrating Jeju's volcanic stones and traditions.",
            7, 120,
            "https://images.unsplash.com/photo-1578637387939-43c525550085");

        Add(list, d, "Jeongbang Waterfall", "Seogwipo",
            "Nature",
            "One of Jeju's famous waterfalls flowing directly toward the sea.",
            9, 90,
            "https://images.unsplash.com/photo-1578637387939-43c525550085");

        Add(list, d, "Jusangjeolli Cliff", "Seogwipo",
            "Nature",
            "Dramatic hexagonal volcanic rock formations along the coast.",
            9, 90,
            "https://images.unsplash.com/photo-1578637387939-43c525550085");

        Add(list, d, "O'Sulloc Tea Museum", "Andeok",
            "Cafe",
            "A relaxing tea destination surrounded by green tea fields.",
            8, 120,
            "https://images.unsplash.com/photo-1578637387939-43c525550085");

        Add(list, d, "Hamdeok Beach", "Jocheon",
            "Beach",
            "A beautiful turquoise-water beach popular for a relaxed afternoon.",
            9, 150,
            "https://images.unsplash.com/photo-1578637387939-43c525550085");
    }

    private static void AddBusan(
        List<Attraction> list,
        List<Destination> destinations)
    {
        var d = Find(destinations, "Busan");

        Add(list, d, "Haeundae Beach", "Haeundae",
            "Beach",
            "Busan's most famous beach and a great place to start exploring the city.",
            10, 150,
            "https://images.unsplash.com/photo-1590253230532-a67f6bc61c9e");

        Add(list, d, "Gamcheon Culture Village", "Saha",
            "Culture",
            "Colourful hillside houses, murals and small artistic streets overlooking the sea.",
            10, 150,
            "https://images.unsplash.com/photo-1590253230532-a67f6bc61c9e");

        Add(list, d, "Jagalchi Market", "Nampo",
            "Food",
            "Busan's famous seafood market.",
            9, 120,
            "https://images.unsplash.com/photo-1590253230532-a67f6bc61c9e");

        Add(list, d, "BIFF Square", "Nampo",
            "Food",
            "A lively area filled with Korean street food and entertainment.",
            8, 120,
            "https://images.unsplash.com/photo-1590253230532-a67f6bc61c9e");

        Add(list, d, "Haedong Yonggungsa Temple", "Gijang",
            "Culture",
            "A spectacular seaside Buddhist temple.",
            10, 150,
            "https://images.unsplash.com/photo-1590253230532-a67f6bc61c9e");

        Add(list, d, "Gwangalli Beach", "Suyeong",
            "Beach",
            "A beautiful beach with views of Gwangan Bridge.",
            9, 150,
            "https://images.unsplash.com/photo-1590253230532-a67f6bc61c9e");

        Add(list, d, "Taejongdae", "Yeongdo",
            "Nature",
            "Clifftop coastal scenery and walking trails.",
            9, 180,
            "https://images.unsplash.com/photo-1590253230532-a67f6bc61c9e");
    }

    private static void AddDaejeon(
        List<Attraction> list,
        List<Destination> destinations)
    {
        var d = Find(destinations, "Daejeon");

        Add(list, d, "Hanbat Arboretum", "Seo-gu",
            "Nature",
            "A large and peaceful botanical garden in the city.",
            9, 120,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");

        Add(list, d, "Yuseong Hot Springs", "Yuseong",
            "Relaxation",
            "A relaxing area known for natural hot springs.",
            9, 120,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");

        Add(list, d, "Expo Science Park", "Yuseong",
            "Science",
            "A landmark area connected to Daejeon's identity as a science city.",
            8, 120,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");

        Add(list, d, "Daejeon O-World", "Jung-gu",
            "Entertainment",
            "A family-friendly amusement and animal park.",
            7, 180,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");

        Add(list, d, "Sky Road", "Jung-gu",
            "Shopping",
            "A lively downtown shopping street.",
            7, 120,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");
    }

    private static void AddSuwon(
        List<Attraction> list,
        List<Destination> destinations)
    {
        var d = Find(destinations, "Suwon");

        Add(list, d, "Hwaseong Fortress", "Paldal-gu",
            "Culture",
            "A UNESCO World Heritage fortress surrounding Suwon's historic centre.",
            10, 180,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");

        Add(list, d, "Hwaseong Haenggung Palace", "Paldal-gu",
            "Culture",
            "A beautiful historic palace connected to King Jeongjo.",
            9, 120,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");

        Add(list, d, "Paldalmun Gate", "Paldal-gu",
            "History",
            "One of Suwon Hwaseong's impressive historic gates.",
            8, 60,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");

        Add(list, d, "Haenggung-dong Cafe Street", "Haenggung-dong",
            "Cafe",
            "Trendy cafés and small shops around the historic fortress area.",
            8, 150,
            "https://images.unsplash.com/photo-1538485399081-7c897b8b1f5c");
    }

    private static void AddHongKong(
        List<Attraction> list,
        List<Destination> destinations)
    {
        var d = Find(destinations, "Hong Kong");

        Add(list, d, "Victoria Peak", "The Peak",
            "Viewpoint",
            "The classic Hong Kong skyline viewpoint.",
            10, 180,
            "https://images.unsplash.com/photo-1577871598838-a543ee47cd79");

        Add(list, d, "Victoria Harbour", "Tsim Sha Tsui",
            "Viewpoint",
            "The iconic harbour separating Hong Kong Island and Kowloon.",
            10, 120,
            "https://images.unsplash.com/photo-1596295426983-c98ba78de039");

        Add(list, d, "Tsim Sha Tsui", "Kowloon",
            "Shopping",
            "A lively waterfront district packed with shopping and restaurants.",
            9, 180,
            "https://images.unsplash.com/photo-1596295426983-c98ba78de039");

        Add(list, d, "Mong Kok", "Kowloon",
            "Shopping",
            "One of Hong Kong's busiest neighbourhoods with markets and street food.",
            9, 180,
            "https://images.unsplash.com/photo-1596295426983-c98ba78de039");

        Add(list, d, "Temple Street Night Market", "Jordan",
            "Food",
            "A classic Hong Kong evening market.",
            8, 120,
            "https://images.unsplash.com/photo-1596295426983-c98ba78de039");

        Add(list, d, "Lantau Island", "Lantau",
            "Nature",
            "A slower side of Hong Kong featuring mountains, villages and the Big Buddha.",
            9, 300,
            "https://images.unsplash.com/photo-1596295426983-c98ba78de039");

        Add(list, d, "Disneyland Hong Kong", "Lantau",
            "Entertainment",
            "A full-day theme park experience.",
            8, 480,
            "https://images.unsplash.com/photo-1596295426983-c98ba78de039");
    }

    private static void AddTaipei(
        List<Attraction> list,
        List<Destination> destinations)
    {
        var d = Find(destinations, "Taipei");

        Add(list, d, "Taipei 101", "Xinyi",
            "Viewpoint",
            "Taipei's iconic skyscraper and city observation deck.",
            10, 150,
            "https://images.unsplash.com/photo-1470004914212-05527e49370b");

        Add(list, d, "Shilin Night Market", "Shilin",
            "Food",
            "One of Taipei's best-known night markets.",
            10, 180,
            "https://images.unsplash.com/photo-1470004914212-05527e49370b");

        Add(list, d, "Chiang Kai-shek Memorial Hall", "Zhongzheng",
            "Culture",
            "One of Taipei's most recognisable historic landmarks.",
            9, 120,
            "https://images.unsplash.com/photo-1470004914212-05527e49370b");

        Add(list, d, "Longshan Temple", "Wanhua",
            "Culture",
            "A historic temple and important cultural landmark.",
            9, 90,
            "https://images.unsplash.com/photo-1470004914212-05527e49370b");

        Add(list, d, "Ximending", "Wanhua",
            "Shopping",
            "Taipei's energetic youth and shopping district.",
            9, 180,
            "https://images.unsplash.com/photo-1470004914212-05527e49370b");

        Add(list, d, "Jiufen", "New Taipei",
            "Culture",
            "A mountain town famous for lantern-lit streets and tea houses.",
            10, 240,
            "https://images.unsplash.com/photo-1470004914212-05527e49370b");

        Add(list, d, "Beitou Hot Springs", "Beitou",
            "Relaxation",
            "A relaxing hot spring district in northern Taipei.",
            8, 180,
            "https://images.unsplash.com/photo-1470004914212-05527e49370b");
    }

    private static void AddBangkok(
        List<Attraction> list,
        List<Destination> destinations)
    {
        var d = Find(destinations, "Bangkok");

        Add(list, d, "Grand Palace", "Rattanakosin",
            "Culture",
            "Bangkok's most famous royal complex.",
            10, 150,
            "https://images.unsplash.com/photo-1508009603885-50cf7c579365");

        Add(list, d, "Wat Arun", "Thon Buri",
            "Culture",
            "A beautiful riverside temple famous for its detailed architecture.",
            10, 120,
            "https://images.unsplash.com/photo-1508009603885-50cf7c579365");

        Add(list, d, "Wat Pho", "Rattanakosin",
            "Culture",
            "Historic temple complex famous for the giant reclining Buddha.",
            9, 120,
            "https://images.unsplash.com/photo-1508009603885-50cf7c579365");

        Add(list, d, "Chatuchak Weekend Market", "Chatuchak",
            "Shopping",
            "One of the world's largest weekend markets.",
            9, 240,
            "https://images.unsplash.com/photo-1508009603885-50cf7c579365");

        Add(list, d, "ICONSIAM", "Khlong San",
            "Shopping",
            "Luxury shopping and riverside dining.",
            8, 180,
            "https://images.unsplash.com/photo-1508009603885-50cf7c579365");

        Add(list, d, "Chinatown Bangkok", "Yaowarat",
            "Food",
            "A fantastic neighbourhood for Thai-Chinese food and night-time exploration.",
            10, 180,
            "https://images.unsplash.com/photo-1508009603885-50cf7c579365");
    }

    private static void AddHoChiMinh(
        List<Attraction> list,
        List<Destination> destinations)
    {
        var d = Find(destinations, "Ho Chi Minh City");

        Add(list, d, "Ben Thanh Market", "District 1",
            "Shopping",
            "A famous central market filled with food, souvenirs and local products.",
            10, 150,
            "https://images.unsplash.com/photo-1583417319070-4a69db38a482");

        Add(list, d, "Notre-Dame Cathedral Basilica", "District 1",
            "Culture",
            "A historic landmark in the heart of the city.",
            8, 60,
            "https://images.unsplash.com/photo-1583417319070-4a69db38a482");

        Add(list, d, "Central Post Office", "District 1",
            "Culture",
            "A beautiful French-colonial landmark next to the cathedral.",
            8, 60,
            "https://images.unsplash.com/photo-1583417319070-4a69db38a482");

        Add(list, d, "War Remnants Museum", "District 3",
            "History",
            "An important museum documenting the Vietnam War.",
            10, 150,
            "https://images.unsplash.com/photo-1583417319070-4a69db38a482");

        Add(list, d, "Nguyen Hue Walking Street", "District 1",
            "Nightlife",
            "A lively pedestrian boulevard in central Ho Chi Minh City.",
            9, 120,
            "https://images.unsplash.com/photo-1583417319070-4a69db38a482");

        Add(list, d, "Bui Vien Street", "District 1",
            "Nightlife",
            "A famous nightlife street filled with restaurants and bars.",
            8, 150,
            "https://images.unsplash.com/photo-1583417319070-4a69db38a482");
    }

    private static void AddCebu(
        List<Attraction> list,
        List<Destination> destinations)
    {
        var d = Find(destinations, "Cebu");

        Add(list, d, "Kawasan Falls", "Badian",
            "Nature",
            "A spectacular waterfall destination famous for turquoise water.",
            10, 300,
            "https://images.unsplash.com/photo-1518509562904-e7ef99cdcc86");

        Add(list, d, "Moalboal Sardine Run", "Moalboal",
            "Beach",
            "An incredible marine experience with huge schools of sardines.",
            10, 180,
            "https://images.unsplash.com/photo-1518509562904-e7ef99cdcc86");

        Add(list, d, "Oslob", "Oslob",
            "Nature",
            "A popular southern Cebu destination surrounded by dramatic coastal scenery.",
            8, 240,
            "https://images.unsplash.com/photo-1518509562904-e7ef99cdcc86");

        Add(list, d, "Magellan's Cross", "Cebu City",
            "History",
            "An important historic landmark in Cebu City.",
            8, 60,
            "https://images.unsplash.com/photo-1518509562904-e7ef99cdcc86");

        Add(list, d, "Temple of Leah", "Cebu City",
            "Viewpoint",
            "A hilltop landmark with views over Cebu.",
            8, 120,
            "https://images.unsplash.com/photo-1518509562904-e7ef99cdcc86");

        Add(list, d, "Mactan Island", "Lapu-Lapu",
            "Beach",
            "A convenient island escape with resorts and beaches.",
            9, 240,
            "https://images.unsplash.com/photo-1518509562904-e7ef99cdcc86");
    }

    private static void AddBali(
        List<Attraction> list,
        List<Destination> destinations)
    {
        var d = Find(destinations, "Bali");

        Add(list, d, "Tegallalang Rice Terraces", "Ubud",
            "Nature",
            "Beautiful terraced rice fields surrounded by tropical greenery.",
            10, 150,
            "https://images.unsplash.com/photo-1537996194471-e657df975ab4");

        Add(list, d, "Sacred Monkey Forest", "Ubud",
            "Nature",
            "A lush forest sanctuary in central Ubud.",
            9, 150,
            "https://images.unsplash.com/photo-1537996194471-e657df975ab4");

        Add(list, d, "Uluwatu Temple", "Uluwatu",
            "Culture",
            "A dramatic clifftop temple overlooking the Indian Ocean.",
            10, 150,
            "https://images.unsplash.com/photo-1537996194471-e657df975ab4");

        Add(list, d, "Seminyak", "Seminyak",
            "Beach",
            "Beach clubs, restaurants, cafés and sunset experiences.",
            9, 180,
            "https://images.unsplash.com/photo-1537996194471-e657df975ab4");

        Add(list, d, "Tanah Lot", "Tabanan",
            "Culture",
            "A famous temple sitting dramatically offshore.",
            10, 120,
            "https://images.unsplash.com/photo-1537996194471-e657df975ab4");

        Add(list, d, "Kelingking Beach", "Nusa Penida",
            "Nature",
            "One of Indonesia's most iconic coastal viewpoints.",
            10, 300,
            "https://images.unsplash.com/photo-1537996194471-e657df975ab4");

        Add(list, d, "Ubud Palace", "Ubud",
            "Culture",
            "A central landmark showcasing Balinese royal architecture.",
            8, 90,
            "https://images.unsplash.com/photo-1537996194471-e657df975ab4");
    }

    private static void AddBatam(
        List<Attraction> list,
        List<Destination> destinations)
    {
        var d = Find(destinations, "Batam");

        Add(list, d, "Barelang Bridge", "Batam",
            "Viewpoint",
            "Batam's most iconic bridge and a popular scenic stop.",
            10, 120,
            "https://images.unsplash.com/photo-1507525428034-b723cf961d3e");

        Add(list, d, "Nongsa Beach", "Nongsa",
            "Beach",
            "A relaxing coastal destination with resort-style scenery.",
            9, 180,
            "https://images.unsplash.com/photo-1507525428034-b723cf961d3e");

        Add(list, d, "Nagoya Hill Shopping Mall", "Nagoya",
            "Shopping",
            "A major shopping and dining destination.",
            8, 180,
            "https://images.unsplash.com/photo-1507525428034-b723cf961d3e");

        Add(list, d, "Maha Vihara Duta Maitreya Temple", "Sei Panas",
            "Culture",
            "A colourful Buddhist temple complex.",
            8, 90,
            "https://images.unsplash.com/photo-1507525428034-b723cf961d3e");
    }

    private static void AddKualaLumpur(
        List<Attraction> list,
        List<Destination> destinations)
    {
        var d = Find(destinations, "Kuala Lumpur");

        Add(list, d, "Petronas Twin Towers", "KLCC",
            "Viewpoint",
            "Malaysia's iconic twin skyscrapers.",
            10, 150,
            "https://images.unsplash.com/photo-1596422846543-75c6fc197f07");

        Add(list, d, "Batu Caves", "Gombak",
            "Culture",
            "A spectacular Hindu temple complex built around limestone caves.",
            10, 150,
            "https://images.unsplash.com/photo-1596422846543-75c6fc197f07");

        Add(list, d, "Bukit Bintang", "Bukit Bintang",
            "Shopping",
            "Kuala Lumpur's energetic shopping and entertainment district.",
            9, 180,
            "https://images.unsplash.com/photo-1596422846543-75c6fc197f07");

        Add(list, d, "Jalan Alor", "Bukit Bintang",
            "Food",
            "A famous street food destination.",
            9, 120,
            "https://images.unsplash.com/photo-1596422846543-75c6fc197f07");

        Add(list, d, "Merdeka Square", "City Centre",
            "History",
            "A historic square surrounded by colonial-era architecture.",
            8, 90,
            "https://images.unsplash.com/photo-1596422846543-75c6fc197f07");

        Add(list, d, "Thean Hou Temple", "Seputeh",
            "Culture",
            "A beautiful Chinese temple overlooking the city.",
            8, 120,
            "https://images.unsplash.com/photo-1596422846543-75c6fc197f07");
    }

    private static void AddJohorBahru(
        List<Attraction> list,
        List<Destination> destinations)
    {
        var d = Find(destinations, "Johor Bahru");

        Add(list, d, "Sultan Abu Bakar State Mosque", "Johor Bahru",
            "Culture",
            "A striking historic mosque overlooking the Straits of Johor.",
            8, 90,
            "https://images.unsplash.com/photo-1596422846543-75c6fc197f07");

        Add(list, d, "KSL City Mall", "Johor Bahru",
            "Shopping",
            "A popular shopping and dining destination.",
            8, 180,
            "https://images.unsplash.com/photo-1596422846543-75c6fc197f07");

        Add(list, d, "Danga Bay", "Danga Bay",
            "Waterfront",
            "A waterfront area for an easy evening.",
            7, 120,
            "https://images.unsplash.com/photo-1596422846543-75c6fc197f07");

        Add(list, d, "LEGOLAND Malaysia", "Iskandar Puteri",
            "Entertainment",
            "A full-day theme park experience.",
            10, 480,
            "https://images.unsplash.com/photo-1596422846543-75c6fc197f07");
    }

    private static void AddMalacca(
        List<Attraction> list,
        List<Destination> destinations)
    {
        var d = Find(destinations, "Malacca");

        Add(list, d, "Jonker Street", "Jonker Walk",
            "Food",
            "Historic street filled with food, shops and cafés.",
            10, 180,
            "https://images.unsplash.com/photo-1596422846543-75c6fc197f07");

        Add(list, d, "A Famosa", "Bandar Hilir",
            "History",
            "One of the oldest surviving European architectural remains in Asia.",
            9, 90,
            "https://images.unsplash.com/photo-1596422846543-75c6fc197f07");

        Add(list, d, "Stadthuys", "Bandar Hilir",
            "History",
            "A famous Dutch-era historic building.",
            9, 90,
            "https://images.unsplash.com/photo-1596422846543-75c6fc197f07");

        Add(list, d, "Melaka River Cruise", "Melaka River",
            "Waterfront",
            "A relaxing cruise through the historic city.",
            9, 90,
            "https://images.unsplash.com/photo-1596422846543-75c6fc197f07");

        Add(list, d, "Klebang Beach", "Klebang",
            "Beach",
            "A relaxed coastal stop outside the historic centre.",
            7, 120,
            "https://images.unsplash.com/photo-1596422846543-75c6fc197f07");
    }
}