export interface Trip {
  id: string;
  destination: string;
  startDate: string;
  endDate: string;
  budget: number;
  days?: number;
}