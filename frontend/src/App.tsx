import { useState } from "react";
import "./App.css";
import TripList from "./pages/TripList";
import MyTrips from "./pages/MyTrips";
import DestinationHome from "./pages/DestinationHome";
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
  if (selectedDestination !== null) {
    return (
      <Itinerary
        destinationId={selectedDestination}
        days={days}
        onBack={() => setSelectedDestination(null)}
        onDaysChange={setDays}
      />
    );
  }
  if (page === "trips") {
    return (
      <MyTrips
        onExplore={() => setPage("explore")}
        onViewItinerary={openSavedItinerary}
      />
    );
  }

  return (
    <DestinationHome
      days={days}
      onDaysChange={setDays}
      onMyTrips={() => setPage("trips")}
      onSelectDestination={setSelectedDestination}
    />
    
  );
}

export default App;
