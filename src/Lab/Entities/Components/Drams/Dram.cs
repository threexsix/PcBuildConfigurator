using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.DRAMs;

public class Dram : IPowered, ICloneable<Dram>
{
    private readonly List<Xmp> _xmps;
    public Dram(
        Gigabyte size,
        MHz frequency,
        IEnumerable<Xmp> xmp,
        MemoryFormFactors memoryFormFactor,
        Ddr ddr,
        Watt power)
    {
        Size = size ?? throw new ArgumentNullException(nameof(size));
        Frequency = frequency ?? throw new ArgumentNullException(nameof(frequency));
        MemoryFormFactor = memoryFormFactor ?? throw new ArgumentNullException(nameof(memoryFormFactor));
        Ddr = ddr ?? throw new ArgumentNullException(nameof(ddr));
        Power = power ?? throw new ArgumentNullException(nameof(power));

        if (xmp == null)
            throw new ArgumentNullException(nameof(xmp));

        _xmps = new List<Xmp>(xmp);
    }

    public Gigabyte Size { get; }
    public MHz Frequency { get; }
    public IReadOnlyCollection<Xmp> Xmp => _xmps;
    public MemoryFormFactors MemoryFormFactor { get; }
    public Ddr Ddr { get; }
    public Watt Power { get; }
    public Dram Clone()
    {
        return new Dram(
            new Gigabyte(Size.Value),
            new MHz(Frequency.Value),
            Xmp,
            MemoryFormFactor,
            Ddr,
            new Watt(Power.Value));
    }
}