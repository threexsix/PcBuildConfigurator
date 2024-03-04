using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PSUs;

public class PsuBuilder
{
    private Watt? _power;

    public PsuBuilder WithPower(Watt power)
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