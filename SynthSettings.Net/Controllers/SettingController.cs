using Microsoft.AspNetCore.Mvc;
using SynthSettings.Core.Models;
using SynthSettings.Core.Interfaces;

namespace SynthSettings.Net.Controllers;

[ApiController]
[Route("[controller]")]
public class SettingController : ControllerBase
{
    private readonly ISettingService _settingService;

    public SettingController(ISettingService settingService)
    {
        _settingService = settingService;
    }


    /// <summary>Get setting by Id</summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Setting>> GetSettingAsync(Guid id)
    {
        var setting = await _settingService.GetSettingAsync(id);

        if (setting == null)
        {
            return NotFound();
        }

        return Ok(setting);
    }

    /// <summary>Get all settings</summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Setting>>> GetAllSettingsAsync()
    {
        var settings = await _settingService.GetAllSettingsAsync();
        return Ok(settings);
    }

    /// <summary>Create a new setting</summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Setting>> CreateTodoAsync(SettingCreate settingCreate)
    {
        var setting = new Setting
        {
            Name = settingCreate.Name,
            Oscillator = settingCreate.Oscillator,
            Envelope = settingCreate.Envelope,
            Filter = settingCreate.Filter
        };

        var createdSetting = await _settingService.CreateSettingAsync(setting);

        return CreatedAtAction(nameof(GetSettingAsync), new { id = createdSetting.Id }, createdSetting);
    }

    /// <summary>Update a setting by Id</summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateSettingAsync(Guid id, Setting updateSetting)
    {
        if (id != updateSetting.Id)
        {
            return BadRequest();
        }

        var setting = await _settingService.GetSettingAsync(id);
        if (setting == null)
        {
            return NotFound();
        }

        await _settingService.UpdateSettingAsync(updateSetting);

        return NoContent();
    }

    /// <summary>Remove a setting by Id</summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteSettingAsync(Guid id)
    {
        var setting = await _settingService.GetSettingAsync(id);
        if (setting == null)
        {
            return NotFound();
        }

        await _settingService.DeleteSettingAsync(id);
        return NoContent();
    }
}