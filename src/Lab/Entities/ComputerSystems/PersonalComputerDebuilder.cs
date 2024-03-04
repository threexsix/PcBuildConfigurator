using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ComputerCases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CPUs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.DRAMs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.GPUs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MemoryStorages;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PluginModules;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PSUs;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystems;

public class PersonalComputerDebuilder : IComputerDebuilder
{
    private ComputerCase _computerCase;
    private Motherboard? _motherboard;
    private ICpu? _cpu;
    private CoolingSystem? _coolingSystem;
    private ICollection<Dram> _drams = new Collection<Dram>();
    private ICollection<Gpu?> _gpus = new Collection<Gpu?>();
    private ICollection<MemoryStorage?> _memoryStorages = new Collection<MemoryStorage?>();
    private WiFiAdapter? _wiFiAdapter;
    private Psu? _psu;

    public PersonalComputerDebuilder(IComputer personalComputer)
    {
        if (personalComputer is null)
            throw new ArgumentNullException(nameof(personalComputer));

        _computerCase = personalComputer.ComputerCase.Clone();
        _motherboard = personalComputer.Motherboard.Clone();
        _cpu = personalComputer.Cpu.Clone();
        _coolingSystem = personalComputer.CoolingSystem.Clone();

        foreach (Dram cur in personalComputer.Drams)
        {
            _drams?.Add(cur.Clone());
        }

        foreach (Gpu? cur in personalComputer.Gpus)
        {
            _gpus?.Add(cur.Clone());
        }

        foreach (MemoryStorage cur in personalComputer.MemoryStorages)
        {
            _memoryStorages?.Add(cur.Clone());
        }

        _wiFiAdapter = personalComputer.WiFiAdapter?.Clone();
        _psu = personalComputer.Psu.Clone();
    }

    public IComputerDebuilder AnotherComputerCase(ComputerCase computerCase)
    {
        _computerCase = computerCase;
        return this;
    }

    public IComputerDebuilder AnotherMotherboard(Motherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public IComputerDebuilder AnotherCpu(Cpu cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IComputerDebuilder AnotherCoolingSystem(CoolingSystem coolingSystem)
    {
        _coolingSystem = coolingSystem;
        return this;
    }

    public IComputerDebuilder AnotherDrams(ICollection<Dram> drams)
    {
        _drams = drams;
        return this;
    }

    public IComputerDebuilder AnotherGpus(ICollection<Gpu?> gpus)
    {
        _gpus = gpus;
        return this;
    }

    public IComputerDebuilder AnotherMemoryStorages(ICollection<MemoryStorage?> memoryStorages)
    {
        _memoryStorages = memoryStorages;
        return this;
    }

    public IComputerDebuilder AnotherWifiAdapter(WiFiAdapter wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;
        return this;
    }

    public IComputerDebuilder AnotherPsu(Psu psu)
    {
        _psu = psu;
        return this;
    }

    public IComputer Rebuild()
    {
        if (_computerCase is null || _motherboard is null || _cpu is null || _coolingSystem is null ||
            _drams is null || _memoryStorages is null || _psu is null)
        {
            throw new PcAssemblyException("Missing key PC parts for rebuilding");
        }

        PersonalComputer.PersonalComputerBuilder pcBuilder = new();
        pcBuilder
            .WithCase(_computerCase)
            .WithMotherboard(_motherboard)
            .WithCpu(_cpu)
            .WithCoolingSystem(_coolingSystem);

        foreach (Dram dram in _drams)
        {
            pcBuilder.WithDram(dram);
        }

        if (_gpus.Count > 0)
        {
            foreach (Gpu? gpu in _gpus)
            {
                pcBuilder.WithGpu(gpu);
            }
        }

        if (_memoryStorages.Count > 0)
        {
            foreach (MemoryStorage? memoryStorage in _memoryStorages)
            {
                pcBuilder.WithMemoryStorage(memoryStorage);
            }
        }

        if (_wiFiAdapter is not null)
        {
            pcBuilder.WithWifiAdapter(_wiFiAdapter);
        }

        pcBuilder
            .WithPsu(_psu);

        return pcBuilder.Build();
    }
}