using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CPUs;

public class CpuBuilder
{
    private MHz? _coreFrequency;
    private Quantity? _coreQuantity;
    private CpuSocket? _socket;
    private Watt? _tdp;
    private Watt? _power;
    private CpuBase? _cpuBase;

    public CpuBuilder WithCoreFrequency(MHz frequency)
    {
        _coreFrequency = frequency;
        return this;
    }

    public CpuBuilder WithCoreQuantity(Quantity quantity)
    {
        _coreQuantity = quantity;
        return this;
    }

    public CpuBuilder WithSocket(CpuSocket cpuSocket)
    {
        _socket = cpuSocket;
        return this;
    }

    public CpuBuilder WithTdp(Watt cpuTdp)
    {
        _tdp = cpuTdp;
        return this;
    }

    public CpuBuilder WithPower(Watt cpuPower)
    {
        _power = cpuPower;
        return this;
    }

    public CpuBuilder WithCpuBase(CpuBase baseType)
    {
        _cpuBase = baseType;
        return this;
    }

    public Cpu Build()
    {
        if (_coreFrequency is null || _coreQuantity is null || _tdp is null || _power is null || _socket is null || _cpuBase is null)
            throw new ArgumentNullException();
        return new Cpu(_coreFrequency, _coreQuantity, _socket, _tdp, _power, _cpuBase);
    }
}