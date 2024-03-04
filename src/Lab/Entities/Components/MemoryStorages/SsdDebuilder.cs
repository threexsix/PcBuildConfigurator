using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MemoryStorages;

public class SsdDebuilder
{
    private MemoryStorageInterfaces _interfaceType;
    private Gigabyte? _size;
    private Gigabyte? _performanceSpeed;
    private Watt? _power;

    public SsdDebuilder(Ssd ssd)
    {
        if (ssd is null)
            throw new ArgumentNullException(nameof(ssd));

        _interfaceType = ssd.InterfaceType;
        _size = ssd.Size;
        _performanceSpeed = ssd.PerformanceSpeed;
        _power = ssd.Power;
    }

    public SsdDebuilder AnotherInterfaceType(MemoryStorageInterfaces type)
    {
        _interfaceType = type;
        return this;
    }

    public SsdDebuilder AnotherSize(Gigabyte storageSize)
    {
        _size = storageSize;
        return this;
    }

    public SsdDebuilder AnotherPerformanceSpeed(Gigabyte speed)
    {
        _performanceSpeed = speed;
        return this;
    }

    public SsdDebuilder AnotherPower(Watt storagePower)
    {
        _power = storagePower;
        return this;
    }

    public Ssd Build()
    {
        if (_size is null || _performanceSpeed is null || _power is null)
            throw new ArgumentNullException();

        return new Ssd(_interfaceType, _size, _performanceSpeed, _power);
    }
}