using SynthSettings.Core.Models;

namespace SynthSettings.Core.Interfaces;

public interface ISettingService
{
    Task<Setting> CreateSettingAsync(Setting setting);
    Task<Setting> UpdateSettingAsync(Setting setting);
    Task<Setting> GetSettingAsync(Guid settingId);
    Task DeleteSettingAsync(Guid settingId);
    Task<List<Setting>> GetAllSettingsAsync();
}