using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PluginModules;

public class WiFiAdapter : IPowered, ICloneable<WiFiAdapter>
{
    public WiFiAdapter(Watt power)
    {
        Power = power ?? throw new ArgumentNullException(nameof(power));
    }

    public Watt Power { get; }
    public WiFiAdapter Clone()
    {
        return new WiFiAdapter(
            new Watt(Power.Value));
    }
}