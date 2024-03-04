using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PluginModules;

public class WifiAdapterDebuilder
{
    private Watt? _power;

    public WifiAdapterDebuilder(WiFiAdapter wifiAdapter)
    {
        if (wifiAdapter is null)
            throw new ArgumentNullException(nameof(wifiAdapter));

        _power = wifiAdapter.Power;
    }

    public WifiAdapterDebuilder AnotherPower(Watt power)
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