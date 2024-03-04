using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ComputerCases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CPUs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.DRAMs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.GPUs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MemoryStorages;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PluginModules;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PSUs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystems;

public interface IComputerBuilder
{
    IComputerBuilder WithCase(ComputerCase computerCase);
    IComputerBuilder WithMotherboard(Motherboard motherboard);
    IComputerBuilder WithCpu(ICpu cpu);
    IComputerBuilder WithCoolingSystem(CoolingSystem coolingSystem);
    IComputerBuilder WithDram(Dram dram);
    IComputerBuilder WithGpu(Gpu? gpu);
    IComputerBuilder WithMemoryStorage(MemoryStorage? memoryStorage);
    IComputerBuilder WithWifiAdapter(WiFiAdapter? wiFiAdapter);
    IComputerBuilder WithPsu(Psu psu);
    IComputer Build();
}