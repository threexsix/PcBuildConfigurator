using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CPUs;

public class CpuDebuilder
{
    private MHz _coreFrequency;
    private Quantity _coreQuantity;
    private CpuSocket _socket;
    private Watt _tdp;
    private Watt _power;
    private CpuBase _cpuBase;

    public CpuDebuilder(Cpu cpu)
    {
        if (cpu is null)
            throw new ArgumentNullException(nameof(cpu));

        _coreFrequency = cpu.CoreFrequency;
        _coreQuantity = cpu.CoreQuantity;
        _socket = cpu.Socket;
        _tdp = cpu.Tdp;
        _power = cpu.Power;
        _cpuBase = cpu.CpuBase;
    }

    public CpuDebuilder AnotherCoreFrequency(MHz frequency)
    {
        _coreFrequency = frequency;
        return this;
    }

    public CpuDebuilder AnotherCoreQuantity(Quantity quantity)
    {
        _coreQuantity = quantity;
        return this;
    }

    public CpuDebuilder AnotherSocket(CpuSocket socket)
    {
        _socket = socket;
        return this;
    }

    public CpuDebuilder AnotherTdp(Watt tdp)
    {
        _tdp = tdp;
        return this;
    }

    public CpuDebuilder AnotherPower(Watt power)
    {
        _power = power;
        return this;
    }

    public CpuDebuilder AnotherCpuBase(CpuBase baseType)
    {
        _cpuBase = baseType;
        return this;
    }

    public Cpu Build()
    {
        return new Cpu(_coreFrequency, _coreQuantity, _socket, _tdp, _power, _cpuBase);
    }
}