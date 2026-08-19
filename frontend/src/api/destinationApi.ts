import type { Destination } from "../types/Destination";

const API_URL = "http://localhost:5051/api";

export async function getDestinations(
  country?: string,
  days?: number
): Promise<Destination[]> {
  const params = new URLSearchParams();

  if (country) {
    params.append("country", country);
  }

  if (days) {
    params.append("days", days.toString());
  }

  const query = params.toString();

  const response = await fetch(
    `${API_URL}/destinations${query ? `?${query}` : ""}`
  );

  if (!response.ok) {
    throw new Error("Failed to load destinations");
  }

  return response.json();
}