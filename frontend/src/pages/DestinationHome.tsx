import { destinations } from "../data/destinations";

interface Props {
  days: number;
  onDaysChange: (days: number) => void;
  onSelectDestination: (id: number) => void;
  onMyTrips: () => void;
}

export default function DestinationHome({
  days,
  onDaysChange,
  onSelectDestination,
  onMyTrips,
}: Props) {
  return (
    <main className="home">
      <nav className="navbar">
        <div className="logo">
          <span>✈</span>
          AI Travel Planner
        </div>

        <div className="nav-links">
          <button>Explore</button>
          <button onClick={onMyTrips}> My Trips </button>
        </div>
      </nav>

      <section className="hero">
        <div className="hero-content">
          <p className="eyebrow">YOUR NEXT ADVENTURE</p>

          <h1>
            Travel more.
            <br />
            <span>Plan less.</span>
          </h1>

          <p className="hero-description">
            Discover beautiful destinations and let AI create a trip that fits
            your time, interests and travel style.
          </p>

          <div className="planner-box">
            <div className="planner-search">
              <span>📍</span>
              <div>
                <small>WHERE TO?</small>
                <strong>Choose a destination</strong>
              </div>
            </div>

            <div className="planner-divider" />

            <div className="planner-days">
              <span>🗓</span>
              <div>
                <small>TRIP LENGTH</small>
                <strong>{days} days</strong>
              </div>
            </div>

            <button className="plan-button">Plan my trip →</button>
          </div>
        </div>
      </section>

      <section className="duration-section">
        <div>
          <p className="section-label">TRIP LENGTH</p>
          <h2>How long are you travelling?</h2>
        </div>

        <div className="duration-picker">
          {Array.from({ length: 8 }, (_, i) => i + 3).map((value) => (
            <button
              key={value}
              className={days === value ? "active" : ""}
              onClick={() => onDaysChange(value)}
            >
              {value}
              <span> days</span>
            </button>
          ))}
        </div>
      </section>

      <section className="destinations-section">
        <div className="section-heading">
          <div>
            <p className="section-label">EXPLORE</p>
            <h2>Where will you go?</h2>
          </div>

          <span>{destinations.length} destinations</span>
        </div>

        <div className="destination-grid">
          {destinations.map((destination) => (
            <article
              className="destination-card"
              key={destination.id}
              onClick={() => onSelectDestination(destination.id)}
              role="button"
              tabIndex={0}
              onKeyDown={(event) => {
                if (event.key === "Enter" || event.key === " ") {
                  onSelectDestination(destination.id);
                }
              }}
            >
              <div className="card-image">
                <img src={destination.imageUrl} alt={destination.city} />

                <span className="country-badge">
                  {destination.flag} {destination.country}
                </span>

                <button
                  className="heart"
                  onClick={(event) => {
                    event.stopPropagation();
                  }}
                >
                  ♡
                </button>

                {/* Optional hover button */}
                <div className="image-explore">Explore →</div>
              </div>

              <div className="card-content">
                <h3>{destination.city}</h3>

                <p>{destination.description}</p>

                <div className="card-footer">
                  <span>
                    ✦ {destination.minDays}–{destination.maxDays} days
                  </span>

                  <button
                    onClick={(event) => {
                      event.stopPropagation();

                      onSelectDestination(destination.id);
                    }}
                  >
                    Explore →
                  </button>
                </div>
              </div>
            </article>
          ))}
        </div>
      </section>
    </main>
  );
}
