using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MemoryStorages;

public abstract class MemoryStorage : IPowered, ICloneable<MemoryStorage>
{
    protected MemoryStorage(
        MemoryStorageInterfaces interfaceType,
        Gigabyte size,
        Gigabyte performanceSpeed,
        Watt power)
    {
        InterfaceType = interfaceType ?? throw new ArgumentNullException(nameof(interfaceType));
        Size = size ?? throw new ArgumentNullException(nameof(size));
        PerformanceSpeed = performanceSpeed ?? throw new ArgumentNullException(nameof(performanceSpeed));
        Power = power ?? throw new ArgumentNullException(nameof(power));
    }

    public MemoryStorageInterfaces InterfaceType { get; }
    public Gigabyte Size { get; }
    public Gigabyte PerformanceSpeed { get; }
    public Watt Power { get; }
    public abstract MemoryStorage Clone();
}