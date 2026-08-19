import axios from "axios";
import type { Trip } from "../types/Trip";

const api = axios.create({
  baseURL: "http://localhost:5051/api",
});

export const getTrips = async (): Promise<Trip[]> => {
  const response = await api.get<Trip[]>("/Trip");
  return response.data;
};