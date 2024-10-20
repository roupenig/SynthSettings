namespace SynthSettings.Repositories.Entities;

public class FilterEntity
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public int Cutoff { get; set; }
    public int Resonance { get; set; }
    public Guid ADSRId { get; set; }
    public ADSREntity ADSR { get; set; } = new();
}