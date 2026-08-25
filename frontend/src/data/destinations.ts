export interface Destination {
  id: number;
  city: string;
  country: string;
  flag: string;
  description: string;
  imageUrl: string;
  minDays: number;
  maxDays: number;
}

export const destinations: Destination[] = [
  {
    id: 1,
    city: "Seoul",
    country: "South Korea",
    flag: "🇰🇷",
    description:
      "Palaces, cafés, shopping, nightlife and the perfect mix of old and new.",
    imageUrl:
      "https://images.unsplash.com/photo-1538485399081-7c897a9b1d8c?auto=format&fit=crop&w=1200&q=85",
    minDays: 3,
    maxDays: 10,
  },
  {
    id: 2,
    city: "Jeju",
    country: "South Korea",
    flag: "🇰🇷",
    description:
      "Volcanic landscapes, turquoise water, waterfalls and peaceful coastal roads.",
    imageUrl:
      "https://images.unsplash.com/photo-1538485399081-7c897a9b1d8c?auto=format&fit=crop&w=1200&q=85",
    minDays: 3,
    maxDays: 10,
  },
  {
    id: 3,
    city: "Busan",
    country: "South Korea",
    flag: "🇰🇷",
    description:
      "Beautiful beaches, colourful villages, seafood markets and coastal views.",
    imageUrl:
      "https://images.unsplash.com/photo-1579589235672-0c6e9c4c2c86?auto=format&fit=crop&w=1200&q=85",
    minDays: 3,
    maxDays: 10,
  },
  {
    id: 4,
    city: "Daejeon",
    country: "South Korea",
    flag: "🇰🇷",
    description:
      "A relaxed city escape with parks, cafés, science and local experiences.",
    imageUrl:
      "https://images.unsplash.com/photo-1534274988757-a28bf1a57c17?auto=format&fit=crop&w=1200&q=85",
    minDays: 3,
    maxDays: 10,
  },
  {
    id: 5,
    city: "Suwon",
    country: "South Korea",
    flag: "🇰🇷",
    description:
      "Historic walls, traditional architecture and one of Korea's most beautiful fortresses.",
    imageUrl:
      "https://images.unsplash.com/photo-1534274988757-a28bf1a57c17?auto=format&fit=crop&w=1200&q=85",
    minDays: 3,
    maxDays: 10,
  },
  {
    id: 6,
    city: "Hong Kong",
    country: "Hong Kong",
    flag: "🇭🇰",
    description:
      "Skyline views, neon streets, islands, markets and incredible food.",
    imageUrl:
      "https://images.unsplash.com/photo-1596295426983-c98ba78de039",
    minDays: 3,
    maxDays: 10,
  },
  {
    id: 7,
    city: "Taipei",
    country: "Taiwan",
    flag: "🇹🇼",
    description:
      "Night markets, mountain views, temples, cafés and incredible street food.",
    imageUrl:
      "https://images.unsplash.com/photo-1470004914212-05527e49370b?auto=format&fit=crop&w=1200&q=85",
    minDays: 3,
    maxDays: 10,
  },
  {
    id: 8,
    city: "Bangkok",
    country: "Thailand",
    flag: "🇹🇭",
    description:
      "Temples, rooftop views, street food, shopping and vibrant city life.",
    imageUrl:
      "https://images.unsplash.com/photo-1508009603885-50cf7c579365?auto=format&fit=crop&w=1200&q=85",
    minDays: 3,
    maxDays: 10,
  },
  {
    id: 9,
    city: "Ho Chi Minh City",
    country: "Vietnam",
    flag: "🇻🇳",
    description:
      "French architecture, cafés, markets, nightlife and incredible Vietnamese food.",
    imageUrl:
      "https://images.unsplash.com/photo-1583417319070-4a69db38a482?auto=format&fit=crop&w=1200&q=85",
    minDays: 3,
    maxDays: 10,
  },
  {
    id: 10,
    city: "Cebu",
    country: "Philippines",
    flag: "🇵🇭",
    description:
      "Crystal-clear water, islands, waterfalls and unforgettable tropical adventures.",
    imageUrl:
      "https://images.unsplash.com/photo-1518509562904-e7ef99cdcc86?auto=format&fit=crop&w=1200&q=85",
    minDays: 3,
    maxDays: 10,
  },
  {
    id: 11,
    city: "Bali",
    country: "Indonesia",
    flag: "🇮🇩",
    description:
      "Rice terraces, temples, beaches, waterfalls and dreamy tropical escapes.",
    imageUrl:
      "https://images.unsplash.com/photo-1537996194471-e657df975ab4?auto=format&fit=crop&w=1200&q=85",
    minDays: 3,
    maxDays: 10,
  },
  {
    id: 12,
    city: "Kuala Lumpur",
    country: "Malaysia",
    flag: "🇲🇾",
    description:
      "Modern skyline, incredible food, shopping and cultural neighbourhoods.",
    imageUrl:
      "https://images.unsplash.com/photo-1596422846543-75c6fc197f07?auto=format&fit=crop&w=1200&q=85",
    minDays: 3,
    maxDays: 10,
  },
  {
    id: 13,
    city: "Johor Bahru",
    country: "Malaysia",
    flag: "🇲🇾",
    description:
      "A relaxed city getaway with cafés, shopping and easy Singapore access.",
    imageUrl:
      "https://images.unsplash.com/photo-1501785888041-af3ef285b470?auto=format&fit=crop&w=1200&q=85",
    minDays: 3,
    maxDays: 10,
  },
  {
    id: 14,
    city: "Malacca",
    country: "Malaysia",
    flag: "🇲🇾",
    description:
      "Colourful streets, colonial architecture, riverside evenings and amazing food.",
    imageUrl:
      "https://images.unsplash.com/photo-1525625293386-3f8f99389edd?auto=format&fit=crop&w=1200&q=85",
    minDays: 3,
    maxDays: 10,
  },
  {
    id: 15,
    city: "Batam",
    country: "Indonesia",
    flag: "🇮🇩",
    description:
      "An easy island escape with resorts, seafood and relaxing coastal experiences.",
    imageUrl:
      "https://images.unsplash.com/photo-1507525428034-b723cf961d3e?auto=format&fit=crop&w=1200&q=85",
    minDays: 3,
    maxDays: 10,
  },
];