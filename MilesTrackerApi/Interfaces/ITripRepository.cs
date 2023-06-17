using System;
using MilesTrackerApi.Models;

namespace MilesTrackerApi.Interfaces
{
	public interface ITripRepository
	{
        Task<ICollection<Trip>> GetTripsAsync();
        Task<Trip> GetTripAsync(int tripId);
        Task<bool> PostTripAsync(Trip trip);
        Task PatchTripAsync(Trip trip);
        Task DeleteTripAsync(Trip trip);
        bool TripsEntityExists();
        bool TripExists(int tripId);
	}
}

