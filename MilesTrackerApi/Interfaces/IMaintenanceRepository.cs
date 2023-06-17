using System;
using MilesTrackerApi.Models;

namespace MilesTrackerApi.Interfaces
{
	public interface IMaintenanceRepository
	{
        Task<ICollection<Maintenance>> GetMaintenancesAsync();
        Task<Maintenance> GetMaintenanceAsync(int maintenanceId);
        Task<bool> PostMaintenanceAsync(Maintenance maintenance);
        Task PatchMaintenanceAsync(Maintenance maintenance);
        Task DeleteMaintenanceAsync(Maintenance maintenance);
        bool MaintenancesEntityExists();
        bool MaintenanceExists(int maintenanceId);
    }
}

