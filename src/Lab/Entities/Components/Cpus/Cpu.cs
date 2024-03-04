using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CPUs;

public class Cpu : ICpu, ICloneable<ICpu>
{
    public Cpu(
        MHz coreFrequency,
        Quantity coreQuantity,
        CpuSocket socket,
        Watt tdp,
        Watt power,
        CpuBase cpuBase)
    {
        CoreFrequency = coreFrequency ?? throw new ArgumentNullException(nameof(coreFrequency));
        CoreQuantity = coreQuantity ?? throw new ArgumentNullException(nameof(coreQuantity));
        Socket = socket ?? throw new ArgumentNullException(nameof(socket));
        Tdp = tdp ?? throw new ArgumentNullException(nameof(tdp));
        Power = power ?? throw new ArgumentNullException(nameof(power));
        CpuBase = cpuBase ?? throw new ArgumentNullException(nameof(cpuBase));
    }

    public MHz CoreFrequency { get; }
    public Quantity CoreQuantity { get; }
    public CpuSocket Socket { get; }
    public Watt Tdp { get; }
    public Watt Power { get; }
    public CpuBase CpuBase { get; }
    public ICpu Clone()
    {
        return new Cpu(
            new MHz(CoreFrequency.Value),
            new Quantity(CoreQuantity.Value),
            Socket,
            new Watt(Tdp.Value),
            new Watt(Power.Value),
            CpuBase);
    }
}