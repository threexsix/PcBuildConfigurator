using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MemoryStorages;

public class HddDebuilder
{
    private MemoryStorageInterfaces _interfaceType;
    private Gigabyte? _size;
    private Gigabyte? _performanceSpeed;
    private Watt? _power;

    public HddDebuilder(Hdd hdd)
    {
        if (hdd is null)
            throw new ArgumentNullException(nameof(hdd));

        _interfaceType = hdd.InterfaceType;
        _size = hdd.Size;
        _performanceSpeed = hdd.PerformanceSpeed;
        _power = hdd.Power;
    }

    public HddDebuilder AnotherInterfaceType(MemoryStorageInterfaces type)
    {
        _interfaceType = type;
        return this;
    }

    public HddDebuilder AnotherSize(Gigabyte storageSize)
    {
        _size = storageSize;
        return this;
    }

    public HddDebuilder AnotherPerformanceSpeed(Gigabyte speed)
    {
        _performanceSpeed = speed;
        return this;
    }

    public HddDebuilder AnotherPower(Watt storagePower)
    {
        _power = storagePower;
        return this;
    }

    public Hdd Build()
    {
        if (_size is null || _performanceSpeed is null || _power is null)
            throw new ArgumentNullException();

        return new Hdd(_interfaceType, _size, _performanceSpeed, _power);
    }
}