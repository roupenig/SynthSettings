using System.ComponentModel.DataAnnotations;

namespace SynthSettings.Core.Models;

public class ADSR
{
    [Required]
    public int Attack { get; set; }
    [Required]
    public int Delay { get; set; }
    [Required]
    public int Sustain { get; set; }
    [Required]
    public int Release { get; set; }
}