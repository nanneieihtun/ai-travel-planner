import { useEffect, useState } from "react";
import { getDestinations } from "../api/destinationApi";
import type { Destination } from "../types/Destination";
import "./TripList.css";

const durations = [3, 4, 5, 6, 7, 8, 9, 10];

export default function TripList() {
  const [destinations, setDestinations] = useState<Destination[]>([]);
  const [selectedCountry, setSelectedCountry] = useState("");
  const [selectedDays, setSelectedDays] = useState<number | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    loadDestinations();
  }, [selectedCountry, selectedDays]);

  async function loadDestinations() {
    try {
      setLoading(true);

      const data = await getDestinations(
        selectedCountry || undefined,
        selectedDays || undefined
      );

      setDestinations(data);
    } catch (error) {
      console.error(error);
    } finally {
      setLoading(false);
    }
  }

  const countries = [
    "South Korea",
    "Hong Kong",
    "Taiwan",
    "Thailand",
    "Vietnam",
    "Philippines",
    "Indonesia",
    "Malaysia",
  ];

  return (
    <div className="travel-page">

      {/* HERO */}

      <section className="hero-section">

        <div className="hero-overlay" />

        <div className="hero-content">

          <span className="hero-label">
            ✦ AI TRAVEL PLANNER
          </span>

          <h1>
            Where will you
            <br />
            <span>go next?</span>
          </h1>

          <p>
            Discover beautiful destinations and let AI create
            the perfect itinerary for your trip.
          </p>

        </div>

      </section>


      {/* FILTER AREA */}

      <section className="explore-section">

        <div className="section-header">

          <div>
            <span className="eyebrow">
              EXPLORE
            </span>

            <h2>
              Find your next escape
            </h2>
          </div>

        </div>


        {/* COUNTRY FILTER */}

        <div className="country-filter">

          <button
            className={!selectedCountry ? "active" : ""}
            onClick={() => setSelectedCountry("")}
          >
            All
          </button>

          {countries.map((country) => (
            <button
              key={country}
              className={
                selectedCountry === country
                  ? "active"
                  : ""
              }
              onClick={() =>
                setSelectedCountry(country)
              }
            >
              {country}
            </button>
          ))}

        </div>


        {/* DURATION */}

        <div className="duration-section">

          <span className="duration-label">
            How long is your trip?
          </span>

          <div className="duration-filter">

            <button
              className={selectedDays === null ? "active" : ""}
              onClick={() => setSelectedDays(null)}
            >
              Any
            </button>

            {durations.map((days) => (
              <button
                key={days}
                className={
                  selectedDays === days
                    ? "active"
                    : ""
                }
                onClick={() => setSelectedDays(days)}
              >
                {days} days
              </button>
            ))}

          </div>

        </div>


        {/* DESTINATION GRID */}

        {loading ? (

          <div className="loading">
            Discovering destinations...
          </div>

        ) : (

          <div className="destination-grid">

            {destinations.map((destination) => (

              <article
                className="destination-card"
                key={destination.id}
              >

                <div className="card-image">

                  <img
                    src={destination.imageUrl}
                    alt={destination.city}
                  />

                  <span className="country-badge">
                    {destination.flag}{" "}
                    {destination.country}
                  </span>

                  <button className="heart">
                    ♡
                  </button>

                </div>


                <div className="card-content">

                  <h3>
                    {destination.city}
                  </h3>

                  <p>
                    {destination.description}
                  </p>

                  <div className="card-footer">

                    <span>
                      ✦ {destination.minDays}–
                      {destination.maxDays} days
                    </span>

                    <button>
                      Explore →
                    </button>

                  </div>

                </div>

              </article>

            ))}

          </div>

        )}

      </section>

    </div>
  );
}