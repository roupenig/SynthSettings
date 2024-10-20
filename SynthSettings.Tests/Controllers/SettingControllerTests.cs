using NSubstitute;
using SynthSettings.Net.Controllers;
using SynthSettings.Core.Interfaces;
using SynthSettings.Core.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace SynthSettings.Tests.Controllers;

public class SettingControllerTests
{
    [Fact]
    public async void GetSettingAsync_ValidId_ReturnsSetting()
    {
        // Arrange
        var settingService = Substitute.For<ISettingService>();
        var settingController = new SettingController(settingService);

        var setting = new Setting
        {
            Id = Guid.NewGuid(),
            Envelope = new Envelope
            {
                Amplitude = 1,
            }
        };

        settingService.GetSettingAsync(setting.Id).Returns(Task.FromResult<Setting>(setting));

        // Act
        var result = await settingController.GetSettingAsync(setting.Id);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
        var resultObject = result.Result as OkObjectResult;
        Assert.NotNull(resultObject);
        Assert.Equal(200, resultObject.StatusCode);
        var resultValue = resultObject.Value as Setting;
        Assert.NotNull(resultValue);
        Assert.Equal(setting.Envelope.Amplitude, resultValue.Envelope.Amplitude);
    }

    [Fact]
    public async void GetSettingAsync_InvalidId_ReturnsNotFound()
    {
        // Arrange
        var settingService = Substitute.For<ISettingService>();
        var settingController = new SettingController(settingService);

        var settingId = Guid.NewGuid();
        settingService.GetSettingAsync(settingId).Returns(Task.FromResult<Setting>(null!));

        // Act
        var result = await settingController.GetSettingAsync(settingId);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
}