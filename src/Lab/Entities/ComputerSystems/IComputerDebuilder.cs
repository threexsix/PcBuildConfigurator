using System.Collections.Generic;
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

public interface IComputerDebuilder
{
    IComputerDebuilder AnotherComputerCase(ComputerCase computerCase);
    IComputerDebuilder AnotherMotherboard(Motherboard motherboard);
    IComputerDebuilder AnotherCpu(Cpu cpu);
    IComputerDebuilder AnotherCoolingSystem(CoolingSystem coolingSystem);
    IComputerDebuilder AnotherDrams(ICollection<Dram> drams);
    IComputerDebuilder AnotherGpus(ICollection<Gpu?> gpus);
    IComputerDebuilder AnotherMemoryStorages(ICollection<MemoryStorage?> memoryStorages);
    IComputerDebuilder AnotherWifiAdapter(WiFiAdapter wiFiAdapter);
    IComputerDebuilder AnotherPsu(Psu psu);
    IComputer Rebuild();
}