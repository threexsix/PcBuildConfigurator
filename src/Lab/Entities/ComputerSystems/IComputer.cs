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
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystems;

public interface IComputer
{
    ComputerCase ComputerCase { get; }
    Motherboard Motherboard { get; }
    ICpu Cpu { get; }
    CoolingSystem CoolingSystem { get; }
    ICollection<Dram> Drams { get; }
    ICollection<Gpu> Gpus { get; }
    ICollection<MemoryStorage> MemoryStorages { get; }
    WiFiAdapter? WiFiAdapter { get; }
    Psu Psu { get; }
    Watt Power { get; }
}