using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MemoryStorages;

public class Ssd : MemoryStorage
{
    public Ssd(
        MemoryStorageInterfaces interfaceType,
        Gigabyte size,
        Gigabyte performanceSpeed,
        Watt powerConsumption)

        : base(interfaceType, size, performanceSpeed, powerConsumption)
    {
    }

    public override Ssd Clone()
    {
        return new Ssd(
            InterfaceType,
            new Gigabyte(Size.Value),
            new Gigabyte(PerformanceSpeed.Value),
            new Watt(Power.Value));
    }
}