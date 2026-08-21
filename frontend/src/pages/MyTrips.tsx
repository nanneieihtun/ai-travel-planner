import { useEffect, useState } from "react";
import { getTrips } from "../api/tripApi";
import type { Trip } from "../types/Trip";
import "./MyTrips.css";

interface Props {
  onExplore: () => void;
  onViewItinerary: (destination: string, days: number) => void;
}

export default function MyTrips({ onExplore, onViewItinerary }: Props) {
  const [trips, setTrips] = useState<Trip[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    loadTrips();
  }, []);

  async function loadTrips() {
    try {
      setLoading(true);

      const data = await getTrips();

      setTrips(data);
    } catch (error) {
      console.error("Failed to load trips:", error);
    } finally {
      setLoading(false);
    }
  }
  function calculateDays(startDate: string, endDate: string): number {
    const start = new Date(startDate);
    const end = new Date(endDate);

    const difference = end.getTime() - start.getTime();

    return Math.round(difference / (1000 * 60 * 60 * 24)) + 1;
  }
  return (
    <main className="my-trips-page">
      <nav className="navbar">
        <div className="logo">
          <span>✈</span>
          AI Travel Planner
        </div>

        <div className="nav-links">
          <button onClick={onExplore}>Explore</button>

          <button className="active-nav">My Trips</button>
        </div>
      </nav>

      <section className="my-trips-hero">
        <span className="eyebrow">YOUR JOURNEY</span>

        <h1>My Trips</h1>

        <p>Your saved adventures, all in one place.</p>
      </section>

      <section className="saved-trips-section">
        {/* SECTION HEADER */}

        {!loading && trips.length > 0 && (
          <div className="saved-trips-header">
            <div>
              <span className="eyebrow">YOUR COLLECTION</span>

              <h2>Saved adventures</h2>
            </div>

            <span className="trip-count">
              {trips.length} {trips.length === 1 ? "trip" : "trips"}
            </span>
          </div>
        )}

        {/* LOADING */}

        {loading && <div className="loading">Loading your trips...</div>}

        {/* EMPTY */}

        {!loading && trips.length === 0 && (
          <div className="empty-trips">
            <div className="empty-icon">✈</div>

            <h2>No trips saved yet</h2>

            <p>
              Explore destinations and save your favourite itineraries here.
            </p>

            <button className="plan-button" onClick={onExplore}>
              Explore destinations →
            </button>
          </div>
        )}

        {/* SAVED TRIPS */}

        {!loading && trips.length > 0 && (
          <div className="saved-trip-grid">
            {trips.map((trip) => (
              <article className="saved-trip-card" key={trip.id}>
                <div className="saved-trip-image">✈</div>

                <div className="saved-trip-content">
                  <span className="trip-days">
                    {calculateDays(trip.startDate, trip.endDate)} DAYS
                  </span>

                  <h2>{trip.destination}</h2>

                  <p>
                    {trip.startDate}
                    {" → "}
                    {trip.endDate}
                  </p>

                  <button
                    onClick={() =>
                      onViewItinerary(
                        trip.destination,
                        calculateDays(trip.startDate, trip.endDate),
                      )
                    }
                  >
                    View itinerary →
                  </button>
                </div>
              </article>
            ))}
          </div>
        )}
      </section>
    </main>
  );
}
