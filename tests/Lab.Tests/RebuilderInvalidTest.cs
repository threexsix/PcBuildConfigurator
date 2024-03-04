using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ComputerCases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CPUs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.DRAMs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.GPUs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MemoryStorages;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards.Chipsets;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PSUs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class RebuilderInValidTest
{
    public static IEnumerable<object[]> InvalidPcAssemblyData()
    {
        yield return new object[]
        {
            new ComputerCase(
                new List<FormFactors> { new FormFactors("MiniITX"), new FormFactors("ATX") },
                new Millimeters(300),
                new Millimeters(90),
                new Watt(15)),

            new Motherboard(
                new FormFactors("ATX"),
                new CpuSocket("AM4"),
                new WifiSupportiveChipset(new Chipset(new Collection<Xmp> { new Xmp(new MHz(7500)) })),
                new Bios(new List<CpuBase> { new CpuBase("Intel9xxx"), new CpuBase("Intel10xxx") }),
                new MemoryFormFactors("DIMM"),
                new Ddr("DDR4"),
                new Gigabyte(64),
                new Quantity(4),
                new Quantity(2),
                new Quantity(2),
                new Quantity(2),
                new Watt(25)),

            new Cpu(
                new MHz(5400),
                new Quantity(8),
                new CpuSocket("AM4"),
                new Watt(120),
                new Watt(90),
                new CpuBase("Intel9xxx")),

            new CoolingSystem(
                new Millimeters(70),
                new List<CpuSocket> { new CpuSocket("AM4"), new CpuSocket("AM5") },
                new Watt(200),
                new Watt(10)),

            new Dram(
                new Gigabyte(8),
                new MHz(2400),
                new Collection<Xmp> { new Xmp(new MHz(7500)) },
                new MemoryFormFactors("DIMM"),
                new Ddr("DDR4"),
                new Watt(25)),
            new Gpu(new Millimeters(50), new Millimeters(100), new Gigabyte(8), new MHz(4800), new Watt(150)),

            new Ssd(new MemoryStorageInterfaces("PCIEx4"), new Gigabyte(512), new Gigabyte(6700), new Watt(25)),

            new Psu(new Watt(850)),

            new Psu(new Watt(10)),
        };
    }

    [Theory]
    [MemberData(nameof(InvalidPcAssemblyData))]
    public void PcAssemblyInvalid(
        ComputerCase computerCase,
        Motherboard motherboard,
        Cpu cpu,
        CoolingSystem coolingSystem,
        Dram dram,
        Gpu gpu,
        Ssd memoryStorage,
        Psu psu,
        Psu anotherPsu)
    {
        // Assign
        PersonalComputer.PersonalComputerBuilder pcBuilder = new();

        // Act and Assert
        PcAssemblyException ex = Assert.Throws<PcAssemblyException>(() =>
        {
            IComputer personalComputer = pcBuilder
                .WithCase(computerCase)
                .WithMotherboard(motherboard)
                .WithCpu(cpu)
                .WithCoolingSystem(coolingSystem)
                .WithDram(dram)
                .WithGpu(gpu)
                .WithMemoryStorage(memoryStorage)
                .WithPsu(psu)
                .Build();

            IComputer anotherPersonalComputer =
                new PersonalComputerDebuilder(personalComputer).AnotherPsu(anotherPsu).Rebuild();
        });

        // Assert
        Assert.Equal("Not enough power to run the system", ex.Message);
    }
}