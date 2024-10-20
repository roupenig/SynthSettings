namespace SynthSettings.Repositories.Entities;

public class OscillatorEntity
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public int Pitch { get; set; }
}