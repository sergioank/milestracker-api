using System;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using MilesTrackerApi.Data;
using MilesTrackerApi.Interfaces;
using MilesTrackerApi.Models;

namespace MilesTrackerApi.Repositories
{
	public class MaintenanceRepository : IMaintenanceRepository
    {
        private readonly DataContext _context;
        public MaintenanceRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task DeleteMaintenanceAsync(Maintenance maintenance)
        {
            if (!MaintenancesEntityExists())
                return;

            _context.Maintenances.Remove(maintenance);
            await _context.SaveChangesAsync();
        }

        public async Task<Maintenance> GetMaintenanceAsync(int maintenanceId)
        {
            var maintenance = await _context.Maintenances.FindAsync(maintenanceId);
            return maintenance;
        }

        public async Task<ICollection<Maintenance>> GetMaintenancesAsync()
        {
            var maintenancesList = await _context.Maintenances.ToListAsync();
            return maintenancesList;
        }

        public bool MaintenanceExists(int MaintenanceId)
        {
            return _context.Maintenances.Any(c => c.Maintenance_Id == MaintenanceId);
        }

        public bool MaintenancesEntityExists()
        {
            var maintenancsExists = _context.Maintenances != null ? true : false;
            return maintenancsExists;
        }

        public async Task PatchMaintenanceAsync(Maintenance maintenance)
        {
            try
            {
                _context.Maintenances.Update(maintenance);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> PostMaintenanceAsync(Maintenance maintenance)
        {
            var maintenancesExists = MaintenancesEntityExists();
            if (!maintenancesExists)
                return false;

            try
            {
                await _context.Maintenances.AddAsync(maintenance);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //throw (ex);
                return false;
            }

            return true;
        }
    }
}

