using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CoolingSystems;

public class CoolingSystem : IPowered, ICloneable<CoolingSystem>
{
    private readonly List<CpuSocket> _sockets;

    public CoolingSystem(
        Millimeters towerHeight,
        IEnumerable<CpuSocket> sockets,
        Watt maxTdp,
        Watt power)
    {
        TowerHeight = towerHeight ?? throw new ArgumentNullException(nameof(towerHeight));
        MaxTdp = maxTdp ?? throw new ArgumentNullException(nameof(maxTdp));
        Power = power ?? throw new ArgumentNullException(nameof(power));

        if (sockets == null)
            throw new ArgumentNullException(nameof(sockets));

        _sockets = new List<CpuSocket>(sockets);
    }

    public Millimeters TowerHeight { get; }
    public IReadOnlyCollection<CpuSocket> Sockets => _sockets;
    public Watt MaxTdp { get; }
    public Watt Power { get; }

    public CoolingSystem Clone()
    {
        return new CoolingSystem(
            new Millimeters(TowerHeight.Value),
            Sockets,
            new Watt(MaxTdp.Value),
            new Watt(Power.Value));
    }
}