namespace SynthSettings.Repositories.Entities;

public class EnvelopeEntity
{
    public Guid Id { get; set; }
    public int Amplitude { get; set; }
    public Guid ADSRId { get; set; }
    public ADSREntity ADSR { get; set; } = new();
}