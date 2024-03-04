using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PluginModules;

public class WifiAdapterBuilder
{
    private Watt? _power;

    public WifiAdapterBuilder WithPower(Watt power)
    {
        _power = power;
        return this;
    }

    public WiFiAdapter Build()
    {
        if (_power is null)
            throw new ArgumentNullException();

        return new WiFiAdapter(_power);
    }
}