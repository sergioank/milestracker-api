using System;
using MilesTrackerApi.Models;

namespace MilesTrackerApi.Interfaces
{
	public interface ISettingRepository
	{
        Task<ICollection<Setting>> GetSettingsAsync();
        Task<Setting> GetSettingAsync(int settingId);
        Task<bool> PostSettingAsync(Setting setting);
        Task PatchSettingAsync(Setting setting);
        Task DeleteSettingAsync(Setting setting);
        bool SettingsEntityExists();
        bool SettingExists(int settingId);
    }
}

