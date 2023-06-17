using System;
using Microsoft.EntityFrameworkCore;
using MilesTrackerApi.Data;
using MilesTrackerApi.Interfaces;
using MilesTrackerApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MilesTrackerApi.Repositories
{
	public class TripRepository : ITripRepository
	{
        private readonly DataContext _context;


        public TripRepository(DataContext context)
        {
            _context = context;
        }

        public async Task DeleteTripAsync(Trip trip)
        {
            if (!TripsEntityExists())
                return;

            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
        }

        public async Task<Trip> GetTripAsync(int tripId)
        {
            var trip = await _context.Trips.FindAsync(tripId);
            return trip;
        }

        public async Task<ICollection<Trip>> GetTripsAsync()
        {
            var tripsList = await _context.Trips.ToListAsync();
            return tripsList;
        }

        public async Task PatchTripAsync(Trip trip)
        {
            try
            {
                _context.Trips.Update(trip);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> PostTripAsync(Trip trip)
        {
            var tripsExists = TripsEntityExists();
            if (!tripsExists)
                return false;

            try
            {
                await _context.Trips.AddAsync(trip);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //throw (ex);
                return false;
            }

            return true;
        }

        public bool TripExists(int tripId)
        {
            return _context.Trips.Any(c => c.Trip_Id == tripId);
        }

        public bool TripsEntityExists()
        {
            var tripsExists = _context.Trips != null ? true : false;
            return tripsExists;
        }
    }
}

