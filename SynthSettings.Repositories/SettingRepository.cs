using Microsoft.EntityFrameworkCore;
using SynthSettings.Repositories.Entities;

namespace SynthSettings.Repositories;

public class SettingRepository : ISettingRepository
{
    private readonly SettingContext _context;
    public SettingRepository(SettingContext settingContext)
    {
        _context = settingContext;
    }

    public IQueryable<SettingEntity> GetAll()
    {
        return _context.Settings.AsQueryable();
    }

    public async Task<SettingEntity?> GetAsync(Guid id)
    {
        return await _context.Settings.FindAsync(id);
    }

    public async Task<SettingEntity> CreateAsync(SettingEntity setting)
    {
        setting.Id = setting.Id == Guid.Empty ? Guid.NewGuid() : setting.Id;
        _context.Add(setting);
        await _context.SaveChangesAsync();
        return setting;
    }

    public async Task RemoveAsync(Guid id)
    {
        var setting = await _context.Settings.FindAsync(id);
        if (setting != null)
        {
            _context.Remove(setting.Oscillator);
            _context.Remove(setting.Envelope.ADSR);
            _context.Remove(setting.Envelope);
            _context.Remove(setting.Filter.ADSR);
            _context.Remove(setting.Filter);

            _context.Remove(setting);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<SettingEntity> UpdateAsync(SettingEntity setting)
    {
        var local = _context.Settings.Local.FirstOrDefault(c => c.Id == setting.Id);
        if (local != null)
        {
            _context.Entry(local).State = EntityState.Detached;
        }

        _context.Entry(setting).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return setting;
    }
}