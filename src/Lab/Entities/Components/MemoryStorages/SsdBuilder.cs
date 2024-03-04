using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MemoryStorages;

public class SsdBuilder
{
    private MemoryStorageInterfaces? _interfaceType;
    private Gigabyte? _size;
    private Gigabyte? _performanceSpeed;
    private Watt? _power;

    public SsdBuilder WithInterfaceType(MemoryStorageInterfaces type)
    {
        _interfaceType = type;
        return this;
    }

    public SsdBuilder WithSize(Gigabyte storageSize)
    {
        _size = storageSize;
        return this;
    }

    public SsdBuilder WithPerformanceSpeed(Gigabyte speed)
    {
        _performanceSpeed = speed;
        return this;
    }

    public SsdBuilder WithPower(Watt storagePower)
    {
        _power = storagePower;
        return this;
    }

    public Ssd Build()
    {
        if (_size is null || _performanceSpeed is null || _power is null || _interfaceType is null)
            throw new ArgumentNullException();

        return new Ssd(_interfaceType, _size, _performanceSpeed, _power);
    }
}