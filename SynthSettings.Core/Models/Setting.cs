using System.ComponentModel.DataAnnotations;

namespace SynthSettings.Core.Models;

public class Setting
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public Oscillator Oscillator { get; set; } = new();
    public Envelope Envelope { get; set; } = new();
    public Filter Filter { get; set; } = new();
}