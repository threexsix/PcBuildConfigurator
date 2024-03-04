using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.DRAMs;

public class DramBuilder
{
    private Gigabyte? _size;
    private MHz? _frequency;
    private IReadOnlyCollection<Xmp>? _xmp;
    private MemoryFormFactors? _memoryFormFactor;
    private Ddr? _ddr;
    private Watt? _power;

    public DramBuilder WithSize(Gigabyte dramSize)
    {
        _size = dramSize;
        return this;
    }

    public DramBuilder WithFrequency(MHz dramFrequency)
    {
        _frequency = dramFrequency;
        return this;
    }

    public DramBuilder WithXmp(IReadOnlyCollection<Xmp>? dramXmp)
    {
        _xmp = dramXmp;
        return this;
    }

    public DramBuilder WithMemoryFormFactor(MemoryFormFactors formFactor)
    {
        _memoryFormFactor = formFactor;
        return this;
    }

    public DramBuilder WithDdrType(Ddr dramDdrType)
    {
        _ddr = dramDdrType;
        return this;
    }

    public DramBuilder WithPower(Watt dramPower)
    {
        _power = dramPower;
        return this;
    }

    public Dram Build()
    {
        if (_size is null || _frequency is null || _power is null || _memoryFormFactor is null || _ddr is null || _xmp is null)
            throw new ArgumentNullException();
        return new Dram(_size, _frequency, _xmp, _memoryFormFactor, _ddr, _power);
    }
}