using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.DRAMs;

public class DramDebuilder
{
    private Gigabyte _size;
    private MHz _frequency;
    private IReadOnlyCollection<Xmp>? _xmp;
    private MemoryFormFactors _memoryFormFactor;
    private Ddr _ddr;
    private Watt _power;

    public DramDebuilder(Dram dram)
    {
        if (dram is null)
            throw new ArgumentNullException(nameof(dram));

        _size = dram.Size;
        _frequency = dram.Frequency;
        _xmp = dram.Xmp;
        _memoryFormFactor = dram.MemoryFormFactor;
        _ddr = dram.Ddr;
        _power = dram.Power;
    }

    public DramDebuilder AnotherSize(Gigabyte dramSize)
    {
        _size = dramSize;
        return this;
    }

    public DramDebuilder AnotherFrequency(MHz dramFrequency)
    {
        _frequency = dramFrequency;
        return this;
    }

    public DramDebuilder AnotherXmp(IReadOnlyCollection<Xmp>? dramXmp)
    {
        _xmp = dramXmp;
        return this;
    }

    public DramDebuilder AnotherMemoryFormFactor(MemoryFormFactors formFactor)
    {
        _memoryFormFactor = formFactor;
        return this;
    }

    public DramDebuilder AnotherDdrType(Ddr dramDdrType)
    {
        _ddr = dramDdrType;
        return this;
    }

    public DramDebuilder AnotherPower(Watt dramPower)
    {
        _power = dramPower;
        return this;
    }

    public Dram Build()
    {
        if (_size is null || _frequency is null || _power is null || _xmp is null)
            throw new ArgumentNullException();
        return new Dram(_size, _frequency, _xmp, _memoryFormFactor, _ddr, _power);
    }
}