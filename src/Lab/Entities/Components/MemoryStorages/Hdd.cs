using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MemoryStorages;

public class Hdd : MemoryStorage
{
    public Hdd(
        MemoryStorageInterfaces interfaceType,
        Gigabyte size,
        Gigabyte performanceSpeed,
        Watt power)

        : base(interfaceType, size, performanceSpeed, power)
    {
    }

    public override Hdd Clone()
    {
        return new Hdd(
            InterfaceType,
            new Gigabyte(Size.Value),
            new Gigabyte(PerformanceSpeed.Value),
            new Watt(Power.Value));
    }
}