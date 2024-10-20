namespace SynthSettings.Repositories.Entities;

public class ADSREntity
{
    public Guid Id { get; set; }
    public int Attack { get; set; }
    public int Delay { get; set; }
    public int Sustain { get; set; }
    public int Release { get; set; }
}