using NSubstitute;
using SynthSettings.Core.Services;
using SynthSettings.Repositories;
using SynthSettings.Repositories.Entities;
using Xunit;

namespace SynthSettings.Net.Tests.Services;

public class SettingServiceTests
{
    [Fact]
    public async Task CreateSettingAsync_ValidSetting_MapsCorrectly()
    {
        // Arrange
        var settingRepository = Substitute.For<ISettingRepository>();
        var settingService = new SettingService(settingRepository);

        var settingEntity = new SettingEntity
        {
            Id = Guid.NewGuid(),
            Envelope = new EnvelopeEntity
            {
                Amplitude = 1,
            }
        };

        settingRepository.GetAsync(settingEntity.Id).Returns(settingEntity);

        // Act
        var setting = await settingService.GetSettingAsync(settingEntity.Id);

        // Assert
        Assert.Equal(settingEntity.Id, setting.Id);
        Assert.Equal(settingEntity.Envelope.Amplitude, setting.Envelope.Amplitude);
    }
}