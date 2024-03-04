using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CPUs;

public abstract class CpuDecorator : ICpu
{
    protected CpuDecorator(ICpu wrappee)
    {
        ArgumentNullException.ThrowIfNull(wrappee);
        Wrappee = wrappee;
        CoreFrequency = wrappee.CoreFrequency;
        CoreQuantity = wrappee.CoreQuantity;
        Socket = wrappee.Socket;
        Tdp = wrappee.Tdp;
        Power = wrappee.Power;
        CpuBase = wrappee.CpuBase;
    }

    public ICpu Wrappee { get; }
    public MHz CoreFrequency { get; }
    public Quantity CoreQuantity { get; }
    public CpuSocket Socket { get; }

    public Watt Tdp { get; }
    public Watt Power { get; }
    public CpuBase CpuBase { get; }
    public abstract ICpu Clone();
}