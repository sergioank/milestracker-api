using System;
using MilesTrackerApi.Models;

namespace MilesTrackerApi.Interfaces
{
	public interface IFuelLogRepository
	{
        Task<ICollection<Fuel_log>> GetFuelLogsAsync();
        Task<Fuel_log> GetFuelLogAsync(int fuelLogId);
        Task<bool> PostFuelLogAsync(Fuel_log fuelLog);
        Task PatchFuelLogAsync(Fuel_log fuelLog);
        Task DeleteFuelLogAsync(Fuel_log fuelLog);
        bool FuelLogsEntityExists();
        bool FuelLogExists(int fuelLogId);
    }
}

