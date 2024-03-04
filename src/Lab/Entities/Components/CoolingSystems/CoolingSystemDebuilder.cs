using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CoolingSystems;

public class CoolingSystemDebuilder
{
    private Millimeters _towerHeight;
    private IReadOnlyCollection<CpuSocket> _sockets;
    private Watt _maxTdp;
    private Watt _power;

    public CoolingSystemDebuilder(CoolingSystem coolingSystem)
    {
        if (coolingSystem is null)
            throw new ArgumentNullException(nameof(coolingSystem));

        _towerHeight = coolingSystem.TowerHeight;
        _sockets = coolingSystem.Sockets;
        _maxTdp = coolingSystem.MaxTdp;
        _power = coolingSystem.Power;
    }

    public CoolingSystemDebuilder AnotherTowerHeight(Millimeters height)
    {
        _towerHeight = height;
        return this;
    }

    public CoolingSystemDebuilder AnotherSockets(IReadOnlyCollection<CpuSocket> sockets)
    {
        _sockets = sockets;
        return this;
    }

    public CoolingSystemDebuilder AnotherMaxTdp(Watt maxTdp)
    {
        _maxTdp = maxTdp;
        return this;
    }

    public CoolingSystemDebuilder AnotherPower(Watt power)
    {
        _power = power;
        return this;
    }

    public CoolingSystem Build()
    {
        if (_towerHeight is null || _sockets is null || _maxTdp is null || _power is null)
            throw new ArgumentNullException();
        return new CoolingSystem(_towerHeight, _sockets, _maxTdp, _power);
    }
}