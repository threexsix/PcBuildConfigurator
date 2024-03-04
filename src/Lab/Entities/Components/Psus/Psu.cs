using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PSUs;

public class Psu : IPowered, ICloneable<Psu>
{
    public Psu(Watt power)
    {
        Power = power ?? throw new ArgumentNullException(nameof(power));
    }

    public Watt Power { get; }
    public Psu Clone()
    {
        return new Psu(
            new Watt(Power.Value));
    }
}