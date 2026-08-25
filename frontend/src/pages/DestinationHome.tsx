import { useEffect, useMemo, useState } from "react";
import { getDestinations } from "../api/destinationApi";
import type { Destination } from "../types/Destination";
import "./DestinationHome.css";

interface Props {
  days: number;
  onDaysChange: (days: number) => void;
  onMyTrips: () => void;
  onSelectDestination: (id: number) => void;
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

const durations = [3, 4, 5, 6, 7, 8, 9, 10];

export default function DestinationHome({
  days,
  onDaysChange,
  onMyTrips,
  onSelectDestination,
}: Props) {
  const [destinations, setDestinations] = useState<Destination[]>([]);
  const [selectedCountry, setSelectedCountry] = useState("");
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    loadDestinations();
  }, [selectedCountry, days]);

  async function loadDestinations() {
    try {
      setLoading(true);

      const data = await getDestinations(
        selectedCountry || undefined,
        days
      );

      setDestinations(data);
    } catch (error) {
      console.error("Failed to load destinations:", error);
    } finally {
      setLoading(false);
    }
  }

  const heroDestinations = useMemo(() => {
    return destinations.slice(0, 4);
  }, [destinations]);

  const popularDestinations = useMemo(() => {
    return destinations.slice(0, 8);
  }, [destinations]);

  return (
    <main className="destination-home">

      {/* NAVBAR */}

      <nav className="navbar">

        <div className="logo">
          <span className="logo-icon">✈</span>
          <span>AI Travel Planner</span>
        </div>

        <div className="nav-links">
          <button className="active-nav">
            Explore
          </button>

           <button onClick={onMyTrips}>My Trips</button>
        </div>

        <button className="nav-plan-button">
          Plan a trip →
        </button>

      </nav>


      {/* HERO */}

      <section className="landing-hero">

        <div className="hero-copy">

          <span className="hero-eyebrow">
            ✦ AI TRAVEL PLANNER
          </span>

          <h1>
            Where will
            <br />
            <em>you go next?</em>
          </h1>

          <p>
            Discover beautiful destinations and let AI
            create a thoughtfully planned itinerary
            around your time.
          </p>

          <button
            className="hero-button"
            onClick={() =>
              document
                .getElementById("explore")
                ?.scrollIntoView({
                  behavior: "smooth",
                })
            }
          >
            Start exploring
            <span>→</span>
          </button>

        </div>


        {/* PHOTO COLLAGE */}

        <div className="hero-collage">

          {heroDestinations[0] && (
            <div className="hero-photo hero-photo-large">
              <img
                src={heroDestinations[0].imageUrl}
                alt={heroDestinations[0].city}
              />

              <div className="hero-photo-label">
                <span>
                  {heroDestinations[0].flag}
                </span>

                {heroDestinations[0].city}
              </div>
            </div>
          )}

          {heroDestinations[1] && (
            <div className="hero-photo hero-photo-small">
              <img
                src={heroDestinations[1].imageUrl}
                alt={heroDestinations[1].city}
              />
            </div>
          )}

          {heroDestinations[2] && (
            <div className="hero-photo hero-photo-bottom">
              <img
                src={heroDestinations[2].imageUrl}
                alt={heroDestinations[2].city}
              />
            </div>
          )}

          {heroDestinations[3] && (
            <div className="hero-photo hero-photo-right">
              <img
                src={heroDestinations[3].imageUrl}
                alt={heroDestinations[3].city}
              />
            </div>
          )}

          <div className="hero-floating-card">
            <span>✦</span>
            <div>
              <strong>AI planned</strong>
              <small>Made for your journey</small>
            </div>
          </div>

        </div>

      </section>


      {/* TRIP PLANNER */}

      <section
        className="planner-section"
        id="explore"
      >

        <div className="planner-header">

          <div>
            <span className="section-eyebrow">
              PLAN YOUR TRIP
            </span>

            <h2>
              Find the perfect escape
            </h2>
          </div>

          <p>
            Choose where you want to go and
            how much time you have.
          </p>

        </div>


        {/* COUNTRY */}

        <div className="filter-block">

          <span className="filter-label">
            Where do you want to go?
          </span>

          <div className="country-filter">

            <button
              className={
                selectedCountry === ""
                  ? "filter-pill active"
                  : "filter-pill"
              }
              onClick={() =>
                setSelectedCountry("")
              }
            >
              🌏 All
            </button>

            {countries.map((country) => (

              <button
                key={country}
                className={
                  selectedCountry === country
                    ? "filter-pill active"
                    : "filter-pill"
                }
                onClick={() =>
                  setSelectedCountry(country)
                }
              >
                {country}
              </button>

            ))}

          </div>

        </div>


        {/* DURATION */}

        <div className="filter-block duration-block">

          <div className="duration-heading">

            <span className="filter-label">
              How long are you staying?
            </span>

            <span className="selected-duration">
              {days} days selected
            </span>

          </div>

          <div className="duration-filter">

            {durations.map((duration) => (

              <button
                key={duration}
                className={
                  days === duration
                    ? "duration-pill active"
                    : "duration-pill"
                }
                onClick={() =>
                  onDaysChange(duration)
                }
              >
                <strong>
                  {duration}
                </strong>

                <span>
                  days
                </span>
              </button>

            ))}

          </div>

        </div>

      </section>


      {/* POPULAR DESTINATIONS */}

      <section className="popular-section">

        <div className="section-title-row">

          <div>
            <span className="section-eyebrow">
              DISCOVER
            </span>

            <h2>
              Popular destinations
            </h2>
          </div>

          <span className="result-count">
            {destinations.length} destinations
          </span>

        </div>


        {loading ? (

          <div className="destination-loading">
            <div className="loading-spinner" />
            <p>
              Discovering beautiful places...
            </p>
          </div>

        ) : popularDestinations.length === 0 ? (

          <div className="no-results">
            <span>✈</span>

            <h3>
              No destinations found
            </h3>

            <p>
              Try another country or trip length.
            </p>
          </div>

        ) : (

          <div className="destination-grid">

            {popularDestinations.map(
              (destination) => (

                <article
                  className="destination-card"
                  key={destination.id}
                  onClick={() =>
                    onSelectDestination(
                      destination.id
                    )
                  }
                  role="button"
                  tabIndex={0}
                  onKeyDown={(event) => {
                    if (
                      event.key === "Enter" ||
                      event.key === " "
                    ) {
                      onSelectDestination(
                        destination.id
                      );
                    }
                  }}
                >

                  <div className="destination-image">

                    <img
                      src={destination.imageUrl}
                      alt={destination.city}
                    />

                    <span className="country-badge">
                      {destination.flag}{" "}
                      {destination.country}
                    </span>

                    <button
                      className="heart-button"
                      onClick={(event) => {
                        event.stopPropagation();
                      }}
                    >
                      ♡
                    </button>

                    <div className="image-explore">
                      View itinerary →
                    </div>

                  </div>


                  <div className="destination-content">

                    <div>

                      <h3>
                        {destination.city}
                      </h3>

                      <p>
                        {destination.description}
                      </p>

                    </div>


                    <div className="destination-footer">

                      <span className="days-range">
                        ✦ {destination.minDays}–
                        {destination.maxDays} days
                      </span>

                      <button
                        onClick={(event) => {
                          event.stopPropagation();

                          onSelectDestination(
                            destination.id
                          );
                        }}
                      >
                        Explore →
                      </button>

                    </div>

                  </div>

                </article>

              )
            )}

          </div>

        )}

      </section>


      {/* TRIP LENGTH FEATURE */}

      <section className="trip-length-section">

        <div className="trip-length-copy">

          <span className="section-eyebrow">
            YOUR TIME, YOUR TRIP
          </span>

          <h2>
            A perfect plan,
            <br />
            whatever your schedule.
          </h2>

          <p>
            Whether you have a quick weekend escape
            or a longer adventure, AI Travel Planner
            adjusts your itinerary to fit your days.
          </p>

        </div>


        <div className="trip-length-options">

          {[
            {
              days: 3,
              title: "Quick escape",
            },
            {
              days: 4,
              title: "Short getaway",
            },
            {
              days: 5,
              title: "Perfect getaway",
            },
            {
              days: 7,
              title: "Long adventure",
            },
          ].map((item) => (

            <button
              key={item.days}
              className={
                days === item.days
                  ? "trip-length-card active"
                  : "trip-length-card"
              }
              onClick={() =>
                onDaysChange(item.days)
              }
            >

              <strong>
                {item.days}
              </strong>

              <span>
                days
              </span>

              <small>
                {item.title}
              </small>

            </button>

          ))}

        </div>

      </section>


      {/* HOW IT WORKS */}

      <section className="how-section">

        <div className="how-header">

          <span className="section-eyebrow">
            HOW IT WORKS
          </span>

          <h2>
            From inspiration to itinerary.
          </h2>

        </div>


        <div className="how-grid">

          <div className="how-card">

            <span className="step-number">
              01
            </span>

            <div className="step-icon">
              🌏
            </div>

            <h3>
              Choose a destination
            </h3>

            <p>
              Pick from the places you want
              to explore.
            </p>

          </div>


          <div className="how-card">

            <span className="step-number">
              02
            </span>

            <div className="step-icon">
              🗓️
            </div>

            <h3>
              Choose your days
            </h3>

            <p>
              Select anywhere from 3 to
              10 days.
            </p>

          </div>


          <div className="how-card">

            <span className="step-number">
              03
            </span>

            <div className="step-icon">
              ✨
            </div>

            <h3>
              Get your itinerary
            </h3>

            <p>
              Discover attractions and
              optimized routes for every day.
            </p>

          </div>

        </div>

      </section>


      {/* FOOTER */}

      <footer className="landing-footer">

        <div className="logo">
          <span className="logo-icon">✈</span>
          AI Travel Planner
        </div>

        <p>
          Plan less. Travel more.
        </p>

      </footer>

    </main>
  );
}