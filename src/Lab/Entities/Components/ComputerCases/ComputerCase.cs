using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ComputerCases;

public class ComputerCase : IPowered, ICloneable<ComputerCase>
{
    private readonly List<FormFactors> _formFactors;
    public ComputerCase(
        IEnumerable<FormFactors> formFactors,
        Millimeters maxLength,
        Millimeters maxHeight,
        Watt power)
    {
        _formFactors = new List<FormFactors>(formFactors);
        MaxLength = maxLength;
        MaxHeight = maxHeight;
        Power = power;
    }

    public IReadOnlyCollection<FormFactors> FormFactors => _formFactors;
    public Millimeters MaxLength { get; }
    public Millimeters MaxHeight { get; }
    public Watt Power { get; }

    public ComputerCase Clone()
    {
        return new ComputerCase(FormFactors, new Millimeters(MaxLength.Value), new Millimeters(MaxHeight.Value), new Watt(Power.Value));
    }
}