using SynthSettings.Core.Models;
using Xunit;
using System.Net.Http.Json;
using System.Net;


namespace SynthSettings.Tests.Integration;

public class SettingControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
{
    private readonly HttpClient _client;

    public SettingControllerIntegrationTests(TestingWebAppFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAllSettingsAsync_WhenCalled_ReturnsSuccessStatusCode()
    {
        var response = await _client.GetAsync("/Setting");
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task CreateSettingAsync_ValidInput_ReturnsCreatedSetting()
    {
        var setting = new SettingCreate
        {
            Name = "test name",
            Oscillator = new() { Pitch = 1, Type = "Sin"},
            Envelope = new()
            {
                Amplitude = 1,
                ADSR = new() { Attack = 1, Delay = 1, Sustain = 1, Release = 1}
            },
            Filter = new()
            {
                Type = "Low Pass",
                Cutoff = 300,
                Resonance = 1,
                ADSR = new() { Attack = 1, Delay = 1, Sustain = 1, Release = 1}
            }
        };

        var content = JsonContent.Create(setting);
        var response = await _client.PostAsync("/Setting", content);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        Assert.Contains("test name", responseString);
    }

    [Fact]
    public async Task CreateSettingAsync_InvalidInput_ReturnsBadRequest()
    {
        var setting = new Dictionary<string, string>
        {
            {"Test", "test" }
        };

        var content = JsonContent.Create(setting);
        var response = await _client.PostAsync("/Setting", content);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}

