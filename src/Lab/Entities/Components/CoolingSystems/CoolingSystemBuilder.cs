using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CoolingSystems;

public class CoolingSystemBuilder
{
    private Millimeters? _towerHeight;
    private List<CpuSocket>? _sockets = new List<CpuSocket>();
    private Watt? _maxTdp;
    private Watt? _power;

    public CoolingSystemBuilder WithTowerHeight(Millimeters height)
    {
        _towerHeight = height;
        return this;
    }

    public CoolingSystemBuilder WithSocket(CpuSocket socket)
    {
        _sockets?.Add(socket);
        return this;
    }

    public CoolingSystemBuilder WithMaxTdp(Watt tdp)
    {
        _maxTdp = tdp;
        return this;
    }

    public CoolingSystemBuilder WithPower(Watt power)
    {
        this._power = power;
        return this;
    }

    public CoolingSystem Build()
    {
        if (_towerHeight is null || _sockets is null || _maxTdp is null || _power is null)
            throw new ArgumentNullException();
        return new CoolingSystem(_towerHeight, _sockets, _maxTdp, _power);
    }
}