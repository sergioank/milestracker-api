using System;
using MilesTrackerApi.Models;

namespace MilesTrackerApi.Interfaces
{
	public interface IVehicleRepository
	{
        Task<ICollection<Vehicle>> GetVehiclesAsync();
        Task<Vehicle> GetVehicleAsync(int vehicleId);
        Task<bool> PostVehicleAsync(Vehicle vehicle);
        Task PatchVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(Vehicle vehicle);
        bool VehiclesEntityExists();
        bool VehicleExists(int vehicleId);
    }
}

