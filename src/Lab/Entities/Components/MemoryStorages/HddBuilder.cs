using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MemoryStorages;

public class HddBuilder
{
    private MemoryStorageInterfaces? _interfaceType;
    private Gigabyte? _size;
    private Gigabyte? _performanceSpeed;
    private Watt? _power;

    public HddBuilder WithInterfaceType(MemoryStorageInterfaces type)
    {
        _interfaceType = type;
        return this;
    }

    public HddBuilder WithSize(Gigabyte storageSize)
    {
        _size = storageSize;
        return this;
    }

    public HddBuilder WithPerformanceSpeed(Gigabyte speed)
    {
        _performanceSpeed = speed;
        return this;
    }

    public HddBuilder WithPower(Watt storagePower)
    {
        _power = storagePower;
        return this;
    }

    public Hdd Build()
    {
        if (_size is null || _performanceSpeed is null || _power is null || _interfaceType is null)
            throw new ArgumentNullException();

        return new Hdd(_interfaceType, _size, _performanceSpeed, _power);
    }
}