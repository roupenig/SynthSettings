using Microsoft.EntityFrameworkCore;
using SynthSettings.Core.Models;
using SynthSettings.Core.Interfaces;
using SynthSettings.Repositories;
using SynthSettings.Repositories.Entities;


namespace SynthSettings.Core.Services;

public class SettingService : ISettingService
{
    private readonly ISettingRepository _settingRepository;

    public SettingService(ISettingRepository settingRepository)
    {
        _settingRepository = settingRepository;
    }

    public async Task<Setting> CreateSettingAsync(Setting setting)
    {
        if (setting == null)
        {
            throw new ArgumentNullException(nameof(setting));
        }

        var settingEntity = new SettingEntity
        {
            Name = setting.Name,
            Oscillator = new OscillatorEntity { Type = setting.Oscillator.Type, Pitch = setting.Oscillator.Pitch},
            Envelope = new EnvelopeEntity {
                Amplitude = setting.Envelope.Amplitude,
                ADSR = new ADSREntity {
                    Attack = setting.Envelope.ADSR.Attack,
                    Delay = setting.Envelope.ADSR.Delay,
                    Sustain = setting.Envelope.ADSR.Sustain,
                    Release = setting.Envelope.ADSR.Release
                }
            },
            Filter = new FilterEntity
            {
                Type = setting.Filter.Type,
                Cutoff = setting.Filter.Cutoff,
                Resonance = setting.Filter.Resonance,
                ADSR = new ADSREntity
                {
                    Attack = setting.Filter.ADSR.Attack,
                    Delay = setting.Filter.ADSR.Delay,
                    Sustain = setting.Filter.ADSR.Sustain,
                    Release = setting.Filter.ADSR.Release
                }
            }
        };

        settingEntity = await _settingRepository.CreateAsync(settingEntity);

        return new Setting
        {
            Id = settingEntity.Id,
            Name = settingEntity.Name,
            Oscillator = setting.Oscillator,
            Envelope = setting.Envelope,
            Filter = setting.Filter
        };
    }

    public async Task DeleteSettingAsync(Guid settingId)
    {
        await _settingRepository.RemoveAsync(settingId);
    }

    public async Task<List<Setting>> GetAllSettingsAsync()
    {
        IQueryable<SettingEntity> query = _settingRepository.GetAll();
        return await query.Select(settingEntity => new Setting
        {
            Id = settingEntity.Id,
            Name = settingEntity.Name,
            Oscillator = new Oscillator { Type = settingEntity.Oscillator.Type, Pitch = settingEntity.Oscillator.Pitch},
            Envelope = new Envelope
            {
                Amplitude = settingEntity.Envelope.Amplitude,
                ADSR = new ADSR
                {
                    Attack = settingEntity.Envelope.ADSR.Attack,
                    Delay = settingEntity.Envelope.ADSR.Delay,
                    Sustain = settingEntity.Envelope.ADSR.Sustain,
                    Release = settingEntity.Envelope.ADSR.Release
                }
            },
            Filter = new Filter
            {
                Type = settingEntity.Filter.Type,
                Cutoff = settingEntity.Filter.Cutoff,
                Resonance = settingEntity.Filter.Resonance,
                ADSR = new ADSR
                {
                    Attack = settingEntity.Filter.ADSR.Attack,
                    Delay = settingEntity.Filter.ADSR.Delay,
                    Sustain = settingEntity.Filter.ADSR.Sustain,
                    Release = settingEntity.Filter.ADSR.Release
                }
            }    
        }).ToListAsync();
    }

    public async Task<Setting> GetSettingAsync(Guid settingId)
    {
        var settingEntity = await _settingRepository.GetAsync(settingId);

        if (settingEntity == null)
        {
            return null;
        }

        return new Setting
        {
            Id = settingEntity.Id,
            Name = settingEntity.Name,
            Oscillator = new Oscillator { Type = settingEntity.Oscillator.Type, Pitch = settingEntity.Oscillator.Pitch },
            Envelope = new Envelope
            {
                Amplitude = settingEntity.Envelope.Amplitude,
                ADSR = new ADSR
                {
                    Attack = settingEntity.Envelope.ADSR.Attack,
                    Delay = settingEntity.Envelope.ADSR.Delay,
                    Sustain = settingEntity.Envelope.ADSR.Sustain,
                    Release = settingEntity.Envelope.ADSR.Release
                }
            },
            Filter = new Filter
            {
                Type = settingEntity.Filter.Type,
                Cutoff = settingEntity.Filter.Cutoff,
                Resonance = settingEntity.Filter.Resonance,
                ADSR = new ADSR
                {
                    Attack = settingEntity.Filter.ADSR.Attack,
                    Delay = settingEntity.Filter.ADSR.Delay,
                    Sustain = settingEntity.Filter.ADSR.Sustain,
                    Release = settingEntity.Filter.ADSR.Release
                }
            }
        };
    }

    public async Task<Setting> UpdateSettingAsync(Setting setting)
    {
        var existingSetting = await _settingRepository.GetAsync(setting.Id);
        if (existingSetting == null)
        {
            return setting;
        }

        var settingEntity = new SettingEntity
        {
            Id = setting.Id,
            Name = setting.Name,
            OscillatorId = existingSetting.OscillatorId,
            Oscillator = new OscillatorEntity {
                Id = existingSetting.Oscillator.Id,
                Type = setting.Oscillator.Type,
                Pitch = setting.Oscillator.Pitch
            },
            EnvelopeId = existingSetting.EnvelopeId,
            Envelope = new EnvelopeEntity
            {
                Id = existingSetting.Envelope.Id,
                Amplitude = setting.Envelope.Amplitude,
                ADSRId = existingSetting.Envelope.ADSRId,
                ADSR = new ADSREntity
                {
                    Id = existingSetting.Envelope.ADSR.Id,
                    Attack = setting.Envelope.ADSR.Attack,
                    Delay = setting.Envelope.ADSR.Delay,
                    Sustain = setting.Envelope.ADSR.Sustain,
                    Release = setting.Envelope.ADSR.Release
                }
            },
            FilterId = existingSetting.FilterId,
            Filter = new FilterEntity
            {
                Id = existingSetting.Filter.Id,
                Type = setting.Filter.Type,
                Cutoff = setting.Filter.Cutoff,
                Resonance = setting.Filter.Resonance,
                ADSRId = existingSetting.Filter.ADSRId,
                ADSR = new ADSREntity
                {
                    Id = existingSetting.Filter.ADSR.Id,
                    Attack = setting.Filter.ADSR.Attack,
                    Delay = setting.Filter.ADSR.Delay,
                    Sustain = setting.Filter.ADSR.Sustain,
                    Release = setting.Filter.ADSR.Release
                }
            }
        };

        settingEntity = await _settingRepository.UpdateAsync(settingEntity);

        return setting;
    }
}