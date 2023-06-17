using System;
using Microsoft.EntityFrameworkCore;
using MilesTrackerApi.Data;
using MilesTrackerApi.Interfaces;
using MilesTrackerApi.Models;

namespace MilesTrackerApi.Repositories
{
	public class VehicleRepository : IVehicleRepository
	{
        private readonly DataContext _context;


        public VehicleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task DeleteVehicleAsync(Vehicle vehicle)
        {
            if (!VehiclesEntityExists())
                return;

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task<Vehicle> GetVehicleAsync(int vehicleId)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleId);
            return vehicle;
        }

        public async Task<ICollection<Vehicle>> GetVehiclesAsync()
        {
            var vehiclesList = await _context.Vehicles.ToListAsync();
            return vehiclesList;
        }

        public async Task PatchVehicleAsync(Vehicle vehicle)
        {
            try
            {
                _context.Vehicles.Update(vehicle);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> PostVehicleAsync(Vehicle vehicle)
        {
            var vehiclesExists = VehiclesEntityExists();
            if (!vehiclesExists)
                return false;

            try
            {
                await _context.Vehicles.AddAsync(vehicle);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //throw (ex);
                return false;
            }

            return true;
        }

        public bool VehicleExists(int vehicleId)
        {
            return _context.Vehicles.Any(c => c.Vehicle_Id == vehicleId);
        }

        public bool VehiclesEntityExists()
        {
            var vehiclesExists = _context.Vehicles != null ? true : false;
            return vehiclesExists;
        }
    }
}

