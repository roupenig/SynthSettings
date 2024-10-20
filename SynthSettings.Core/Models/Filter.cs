using System.ComponentModel.DataAnnotations;

namespace SynthSettings.Core.Models;

public class Filter
{
    [Required]
    public string Type { get; set; } = string.Empty;
    [Required]
    public int Cutoff { get; set; }
    [Required]
    public int Resonance { get; set; }
    public ADSR ADSR { get; set; } = new();
}