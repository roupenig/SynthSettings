using Microsoft.EntityFrameworkCore;
using Xunit;
using SynthSettings.Repositories.Entities;
using SynthSettings.Repositories;

namespace SynthSettings.Tests.Repositories;

public class SettingRepositoryTests
{
    private readonly DbContextOptions<SettingContext> contextOptions;
    public SettingRepositoryTests()
    {
        contextOptions = new DbContextOptionsBuilder<SettingContext>().UseInMemoryDatabase("TestDatabase").Options;
    }

    [Fact]
    public async Task CreateAsync_ValidSetting_CreatesSetting()
    {
        // Arrange
        SettingEntity testSetting = new()
        {
            Id = Guid.NewGuid(),
            Envelope = new EnvelopeEntity
            {
                Amplitude = 1,
            }
        };

        // Act
        using (var context = new SettingContext(contextOptions))
        {
            var repository = new SettingRepository(context);
            await repository.CreateAsync(testSetting);
        }

        // Assert
        using (var context = new SettingContext(contextOptions))
        {
            var setting = await context.Settings.FindAsync(testSetting.Id);

            Assert.NotNull(setting);
            Assert.Equal(testSetting.Id, setting.Id);
            Assert.Equal(testSetting.Envelope.Amplitude, setting.Envelope.Amplitude);
        }
    }

    [Fact]
    public async Task GetAll_ExistingData_ReturnsData()
    {
        // Arrange
        SettingEntity testSetting = new()
        {
            Id = Guid.NewGuid(),
            Envelope = new EnvelopeEntity
            {
                Amplitude = 1,
            }
        };
        using (var context = new SettingContext(contextOptions))
        {
            var repository = new SettingRepository(context);
            await repository.CreateAsync(testSetting);
        }

        using (var context = new SettingContext(contextOptions))
        {
            // Act
            var repository = new SettingRepository(context);
            var all = repository.GetAll();

            // Assert
            Assert.NotNull(all);
        }
    }

    [Fact]
    public async Task GetAsync_ExistingData_ReturnsData()
    {
        // Arrange
        SettingEntity testSetting = new()
        {
            Id = Guid.NewGuid(),
            Envelope = new EnvelopeEntity
            {
                Amplitude = 1,
            }
        };
        using (var context = new SettingContext(contextOptions))
        {
            var repository = new SettingRepository(context);
            await repository.CreateAsync(testSetting);
        }

        using (var context = new SettingContext(contextOptions))
        {
            // Act
            var repository = new SettingRepository(context);
            var setting = await repository.GetAsync(testSetting.Id);

            // Assert
            Assert.NotNull(setting);
            Assert.Equal(testSetting.Id, setting.Id);
            Assert.Equal(testSetting.Envelope.Amplitude, setting.Envelope.Amplitude);
        }
    }

    [Fact]
    public async Task UpdateAsync_ExistingData_ReturnsUpdatedData()
    {
        // Arrange
        SettingEntity testSetting = new()
        {
            Id = Guid.NewGuid(),
            Envelope = new EnvelopeEntity
            {
                Amplitude = 1,
            }
        };
        using (var context = new SettingContext(contextOptions))
        {
            var repository = new SettingRepository(context);
            await repository.CreateAsync(testSetting);
        }

        using (var context = new SettingContext(contextOptions))
        {
            // Act
            var repository = new SettingRepository(context);
            testSetting.Envelope.Amplitude = 2;
            var setting = await repository.UpdateAsync(testSetting);

            // Assert
            Assert.NotNull(setting);
            Assert.Equal(testSetting.Id, setting.Id);
            Assert.Equal(testSetting.Envelope.Amplitude, setting.Envelope.Amplitude);
        }
    }

    [Fact]
    public async Task RemoveAsync_ExistingData_RemovedFromContext()
    {
        // Arrange
        SettingEntity testSetting = new()
        {
            Id = Guid.NewGuid(),
            Envelope = new EnvelopeEntity
            {
                Amplitude = 1,
            }
        };
        using (var context = new SettingContext(contextOptions))
        {
            var repository = new SettingRepository(context);
            await repository.CreateAsync(testSetting);
        }

        using (var context = new SettingContext(contextOptions))
        {
            // Act
            var repository = new SettingRepository(context);
            await repository.RemoveAsync(testSetting.Id);

            var setting = await context.Settings.FindAsync(testSetting.Id);

            // Assert
            Assert.Null(setting);
        }
    }
}