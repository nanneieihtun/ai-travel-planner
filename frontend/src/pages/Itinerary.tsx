import { useEffect, useState } from "react";
import { createTrip } from "../api/tripApi";

interface Props {
  destinationId: number;
  days: number;
  onDaysChange: (days: number) => void;
  onBack: () => void;
}

interface Stop {
  attractionId: number;
  name: string;
  area: string;
  category: string;
  description: string;
  imageUrl: string;
  visitDurationMinutes: number;
  stopOrder: number;
}

interface ItineraryDay {
  day: number;
  title: string;
  stops: Stop[];
}

interface ItineraryResponse {
  destinationId: number;
  destination: string;
  days: number;
  itinerary: ItineraryDay[];
}

export default function Itinerary({
  destinationId,
  days,
  onDaysChange,
  onBack,
}: Props) {
  const [data, setData] = useState<ItineraryResponse | null>(null);
  const [loading, setLoading] = useState(false);

  // Save state
  const [saving, setSaving] = useState(false);
  const [saved, setSaved] = useState(false);

  useEffect(() => {
    const loadItinerary = async () => {
      setLoading(true);
      setSaved(false);

      try {
        const response = await fetch(
          `http://localhost:5051/api/destinations/${destinationId}/itinerary?days=${days}`
        );

        if (!response.ok) {
          throw new Error("Failed to load itinerary");
        }

        const result: ItineraryResponse = await response.json();

        setData(result);
      } catch (error) {
        console.error("Failed to load itinerary:", error);
        setData(null);
      } finally {
        setLoading(false);
      }
    };

    loadItinerary();
  }, [destinationId, days]);

  const handleSaveTrip = async () => {
    if (!data) return;

    try {
      setSaving(true);

      await createTrip(data.destination, days);

      setSaved(true);
    } catch (error) {
      console.error("Failed to save trip:", error);
    } finally {
      setSaving(false);
    }
  };

  return (
    <main className="itinerary-page">
      {/* HEADER */}
      <header className="itinerary-header">
        <button className="back-button" onClick={onBack}>
          ← Explore destinations
        </button>

        <div className="itinerary-logo">
          ✈ AI Travel Planner
        </div>
      </header>

      {/* HERO */}
      <section className="itinerary-hero">
        <div>
          <p className="section-label">YOUR TRIP</p>

          <h1>
            {data?.destination ?? "Your destination"}
          </h1>

          <p>
            A thoughtfully planned {days}-day adventure.
          </p>

          {/* SAVE BUTTON */}
          <button
            className="save-trip-button"
            onClick={handleSaveTrip}
            disabled={saving || saved || !data}
          >
            {saved
              ? "✓ Saved to My Trips"
              : saving
              ? "Saving..."
              : "♡ Save to My Trips"}
          </button>
        </div>
      </section>

      {/* DURATION */}
      <section className="itinerary-controls">
        <div>
          <p className="section-label">TRIP LENGTH</p>
          <h2>Choose your days</h2>
        </div>

        <div className="duration-picker">
          {Array.from({ length: 8 }, (_, i) => i + 3).map(
            (value) => (
              <button
                key={value}
                className={days === value ? "active" : ""}
                onClick={() => onDaysChange(value)}
              >
                {value}
                <span> days</span>
              </button>
            )
          )}
        </div>
      </section>

      {/* ITINERARY */}
      <section className="timeline">
        {loading && (
          <div className="loading">
            Creating your perfect itinerary...
          </div>
        )}

        {!loading && data?.itinerary.length === 0 && (
          <div className="empty-itinerary">
            <h2>No itinerary available yet</h2>
            <p>
              We haven't added enough attractions for this
              destination yet.
            </p>
          </div>
        )}

        {!loading &&
          data?.itinerary.map((day) => (
            <div className="day-section" key={day.day}>
              <div className="day-marker">
                <span>DAY</span>
                <strong>{day.day}</strong>
              </div>

              <div className="day-content">
                <h2>{day.title}</h2>

                <div className="stops">
                  {day.stops.map((stop) => (
                    <article
                      className="stop-card"
                      key={`${day.day}-${stop.attractionId}`}
                    >
                      <img
                        src={stop.imageUrl}
                        alt={stop.name}
                      />

                      <div className="stop-info">
                        <span className="stop-category">
                          {stop.category}
                        </span>

                        <h3>{stop.name}</h3>

                        <p className="stop-area">
                          📍 {stop.area}
                        </p>

                        <p>{stop.description}</p>

                        <div className="stop-duration">
                          ⏱ {stop.visitDurationMinutes} min
                        </div>
                      </div>
                    </article>
                  ))}
                </div>
              </div>
            </div>
          ))}
      </section>
    </main>
  );
}