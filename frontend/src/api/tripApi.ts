import axios from "axios";
import type { Trip } from "../types/Trip";

const api = axios.create({
  baseURL: "http://localhost:5051/api",
});

export const getTrips = async (): Promise<Trip[]> => {
  const response = await api.get<Trip[]>("/Trip");
  return response.data;
};

export const createTrip = async (
  destination: string,
  days: number
): Promise<Trip> => {
  const today = new Date();

  const startDate = today.toISOString().split("T")[0];

  const end = new Date(today);
  end.setDate(today.getDate() + days - 1);

  const endDate = end.toISOString().split("T")[0];

  const response = await api.post<Trip>("/Trip", {
    destination,
    startDate,
    endDate,
    budget: 0,
    days,
  });

  return response.data;
};