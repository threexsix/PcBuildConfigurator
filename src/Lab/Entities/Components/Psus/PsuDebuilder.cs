using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PSUs;

public class PsuDebuilder
{
    private Watt? _power;

    public PsuDebuilder(Psu psu)
    {
        if (psu is null)
            throw new ArgumentNullException(nameof(psu));

        _power = psu.Power;
    }

    public PsuDebuilder AnotherPower(Watt power)
    {
        _power = power;
        return this;
    }

    public Psu Build()
    {
        if (_power is null)
            throw new ArgumentNullException();

        return new Psu(_power);
    }
}