using SynthSettings.Repositories.Entities;

namespace SynthSettings.Repositories;

public interface ISettingRepository
{
    IQueryable<SettingEntity> GetAll();
    Task<SettingEntity?> GetAsync(Guid id);
    Task<SettingEntity> CreateAsync(SettingEntity setting);
    Task<SettingEntity> UpdateAsync(SettingEntity setting);
    Task RemoveAsync(Guid id);
}