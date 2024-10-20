using System.ComponentModel.DataAnnotations;

namespace SynthSettings.Core.Models;

public class Oscillator
{
    [Required]
    public string Type { get; set; } = string.Empty;
    [Required]
    public int Pitch { get; set; }
}