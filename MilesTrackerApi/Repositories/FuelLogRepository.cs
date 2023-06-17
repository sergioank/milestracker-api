using System;
using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore;
using MilesTrackerApi.Data;
using MilesTrackerApi.Interfaces;
using MilesTrackerApi.Models;

namespace MilesTrackerApi.Repositories
{
	public class FuelLogRepository : IFuelLogRepository
	{
        private readonly DataContext _context;

		public FuelLogRepository(DataContext context)
		{
            _context = context;
		}

        public async Task DeleteFuelLogAsync(Fuel_log fuelLog)
        {
            if (!FuelLogsEntityExists())
                return;

            _context.FuelLogs.Remove(fuelLog);
            await _context.SaveChangesAsync();
        }

        public bool FuelLogExists(int FuelLogId)
        {
            return _context.FuelLogs.Any(c => c.Fuel_log_id == FuelLogId);
        }

        public bool FuelLogsEntityExists()
        {
            var fuelLogsExists = _context.FuelLogs != null ? true : false;
            return fuelLogsExists;
        }

        public async Task<Fuel_log> GetFuelLogAsync(int FuelLogId)
        {
            var fuelLog = await _context.FuelLogs.FindAsync(FuelLogId);
            return fuelLog;
        }

        public async Task<ICollection<Fuel_log>> GetFuelLogsAsync()
        {
            var fuelLogsList = await _context.FuelLogs.ToListAsync();
            return fuelLogsList;
        }

        public async Task PatchFuelLogAsync(Fuel_log fuelLog)
        {
            try
            {
                _context.FuelLogs.Update(fuelLog);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> PostFuelLogAsync(Fuel_log fuelLog)
        {
            var fuelLogsExists = FuelLogsEntityExists();
            if (!fuelLogsExists)
                return false;

            try
            {
                await _context.FuelLogs.AddAsync(fuelLog);
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

