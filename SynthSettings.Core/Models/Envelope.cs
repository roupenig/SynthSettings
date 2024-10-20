using System.ComponentModel.DataAnnotations;

namespace SynthSettings.Core.Models;

public class Envelope
{
    [Required]
    public int Amplitude { get; set; }
    public ADSR ADSR { get; set; } = new();
}