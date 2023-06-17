using System;
using Microsoft.EntityFrameworkCore;
using MilesTrackerApi.Data;
using MilesTrackerApi.Interfaces;
using MilesTrackerApi.Models;

namespace MilesTrackerApi.Repositories
{
	public class SettingRepository : ISettingRepository
	{
        private readonly DataContext _context;
        

        public SettingRepository(DataContext context)
		{
            _context = context;
        }

        public async Task DeleteSettingAsync(Setting setting)
        {
            if (!SettingsEntityExists())
                return;

            _context.Settings.Remove(setting);
            await _context.SaveChangesAsync();
        }

        public async Task<Setting> GetSettingAsync(int settingId)
        {
            var setting = await _context.Settings.FindAsync(settingId);
            return setting;
        }

        public async Task<ICollection<Setting>> GetSettingsAsync()
        {
            var settingsList = await _context.Settings.ToListAsync();
            return settingsList;
        }

        public async Task PatchSettingAsync(Setting setting)
        {
            try
            {
                _context.Settings.Update(setting);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> PostSettingAsync(Setting setting)
        {
            var settingsExists = SettingsEntityExists();
            if (!settingsExists)
                return false;

            try
            {
                await _context.Settings.AddAsync(setting);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //throw (ex);
                return false;
            }

            return true;
        }

        public bool SettingExists(int settingId)
        {
            return _context.Settings.Any(c => c.Setting_Id == settingId);
        }

        public bool SettingsEntityExists()
        {
            var settingsExists = _context.Settings != null ? true : false;
            return settingsExists;
        }
    }
}

