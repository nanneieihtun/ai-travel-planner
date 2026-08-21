import { useState } from "react";
import "./App.css";

import TripList from "./pages/TripList";
import MyTrips from "./pages/MyTrips";
import Itinerary from "./pages/Itinerary";
import { getDestinations } from "./api/destinationApi";

type Page = "explore" | "trips" | "itinerary";

function App() {
  const [page, setPage] = useState<Page>("explore");

  const [selectedDestination, setSelectedDestination] = useState<number | null>(
    null,
  );

  const [days, setDays] = useState(5);
  async function openSavedItinerary(destinationName: string, tripDays: number) {
    try {
      const destinations = await getDestinations();

      const destination = destinations.find(
        (x) => x.city.toLowerCase() === destinationName.toLowerCase(),
      );

      if (!destination) {
        console.error("Destination not found:", destinationName);
        return;
      }

      setSelectedDestination(destination.id);
      setDays(tripDays);
      setPage("itinerary");
    } catch (error) {
      console.error("Failed to find destination:", error);
    }
  }
  // My Trips
  if (page === "trips") {
    return (
      <MyTrips
        onExplore={() => setPage("explore")}
        onViewItinerary={openSavedItinerary}
      />
    );
  }

  // Itinerary
  if (page === "itinerary" && selectedDestination !== null) {
    return (
      <Itinerary
        destinationId={selectedDestination}
        days={days}
        onDaysChange={setDays}
        onBack={() => setPage("explore")}
      />
    );
  }

  // Explore
  return (
    <TripList
      onMyTrips={() => setPage("trips")}
      onSelectDestination={(id) => {
        setSelectedDestination(id);
        setPage("itinerary");
      }}
    />
  );
}

export default App;
