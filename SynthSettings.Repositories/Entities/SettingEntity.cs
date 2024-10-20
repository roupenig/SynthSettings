namespace SynthSettings.Repositories.Entities;

public class SettingEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid OscillatorId { get; set; }
    public OscillatorEntity Oscillator { get; set; } = new();
    public Guid EnvelopeId { get; set; }
    public EnvelopeEntity Envelope { get; set; } = new();
    public Guid FilterId { get; set; }
    public FilterEntity Filter { get; set; } = new();
}