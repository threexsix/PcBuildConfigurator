using System;
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
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystems;

public class PersonalComputer : IComputer
{
    private PersonalComputer(
        ComputerCase computerCase,
        Motherboard motherboard,
        ICpu cpu,
        CoolingSystem coolingSystem,
        ICollection<Dram> drams,
        ICollection<Gpu> gpus,
        ICollection<MemoryStorage> memoryStorages,
        WiFiAdapter? wiFiAdapter,
        Watt power,
        Psu psu)
    {
        ComputerCase = computerCase ?? throw new ArgumentNullException(nameof(computerCase));
        Motherboard = motherboard ?? throw new ArgumentNullException(nameof(motherboard));
        Cpu = cpu ?? throw new ArgumentNullException(nameof(cpu));
        CoolingSystem = coolingSystem ?? throw new ArgumentNullException(nameof(coolingSystem));
        Drams = drams ?? throw new ArgumentNullException(nameof(drams));
        Gpus = gpus ?? throw new ArgumentNullException(nameof(gpus));
        MemoryStorages = memoryStorages ?? throw new ArgumentNullException(nameof(memoryStorages));
        Psu = psu ?? throw new ArgumentNullException(nameof(psu));
        Power = power ?? throw new ArgumentNullException(nameof(power));
        WiFiAdapter = wiFiAdapter;
    }

    public ComputerCase ComputerCase { get; }
    public Motherboard Motherboard { get; }
    public ICpu Cpu { get; }
    public CoolingSystem CoolingSystem { get; }
    public ICollection<Dram> Drams { get; }
    public ICollection<Gpu> Gpus { get; }
    public ICollection<MemoryStorage> MemoryStorages { get; }
    public WiFiAdapter? WiFiAdapter { get; }
    public Psu Psu { get; }
    public Watt Power { get; }

    public class PersonalComputerBuilder : IComputerBuilder
    {
        private readonly List<Dram> _drams;
        private readonly List<Gpu> _gpus;
        private readonly List<MemoryStorage> _sataMemoryStorages;
        private readonly List<MemoryStorage> _pcieX4MemoryStorages;
        private readonly List<MemoryStorage> _memoryStorages;

        public PersonalComputerBuilder()
        {
        _drams = new List<Dram>();
        _gpus = new List<Gpu>();
        _sataMemoryStorages = new List<MemoryStorage>();
        _pcieX4MemoryStorages = new List<MemoryStorage>();
        _memoryStorages = new List<MemoryStorage>();
        TotalPowerConsumption = new Watt(0);
        }

        public IReadOnlyCollection<Dram> Drams => _drams;
        public IReadOnlyCollection<Gpu?> Gpus => _gpus;
        public IReadOnlyCollection<MemoryStorage?> SataMemoryStorages => _sataMemoryStorages;
        public IReadOnlyCollection<MemoryStorage?> PcieX4MemoryStorages => _pcieX4MemoryStorages;
        public IReadOnlyCollection<MemoryStorage> MemoryStorages => _memoryStorages;
        public ComputerCase? ComputerCase { get; private set; }
        public Motherboard? Motherboard { get; private set; }
        public ICpu? Cpu { get; private set; }
        public CoolingSystem? CoolingSystem { get; private set; }
        public WiFiAdapter? WiFiAdapter { get; private set; }
        public Psu? Psu { get; private set; }
        public Watt TotalPowerConsumption { get; private set; }

        public IComputerBuilder WithCase(ComputerCase computerCase)
        {
            ComputerCase = computerCase;
            TotalPowerConsumption += ComputerCase.Power;
            return this;
        }

        public IComputerBuilder WithMotherboard(Motherboard motherboard)
        {
            new MotherboardCompatibilityValidator(motherboard).ValidateMotherboardCompatibility(ComputerCase);

            Motherboard = motherboard;
            TotalPowerConsumption += Motherboard.Power;
            return this;
        }

        public IComputerBuilder WithCpu(ICpu cpu)
        {
            new CpuCompatibilityValidator(cpu).ValidateCpuCompatibility(Motherboard);

            Cpu = cpu;
            TotalPowerConsumption += Cpu.Power;
            return this;
        }

        public IComputerBuilder WithCoolingSystem(CoolingSystem coolingSystem)
        {
            new CoolingSystemCompatibilityValidator(coolingSystem).ValidateCoolingSystemCompatibility(Cpu, ComputerCase);

            CoolingSystem = coolingSystem;
            TotalPowerConsumption += CoolingSystem.Power;
            return this;
        }

        public IComputerBuilder WithDram(Dram dram)
        {
            new DramCompatibilityValidator(dram).ValidateDramCompatibility(Motherboard, Drams);

            _drams.Add(dram);
            TotalPowerConsumption += dram.Power;
            return this;
        }

        public IComputerBuilder WithGpu(Gpu? gpu)
        {
            if (gpu is null)
                ArgumentNullException.ThrowIfNull(gpu);

            new GpuCompatibilityValidator(gpu).ValidateGpuCompatibility(ComputerCase, Motherboard, Gpus);

            _gpus.Add(gpu);
            TotalPowerConsumption += gpu.Power;
            return this;
        }

        public IComputerBuilder WithMemoryStorage(MemoryStorage? memoryStorage)
        {
            if (memoryStorage is null)
                ArgumentNullException.ThrowIfNull(memoryStorage);

            new MemoryStorageCompatibilityValidator(memoryStorage).ValidateMemoryStorageCompatibility(Motherboard, SataMemoryStorages, PcieX4MemoryStorages);

            if (memoryStorage.InterfaceType.Equals(new MemoryStorageInterfaces("PCIEx4")))
                _pcieX4MemoryStorages.Add(memoryStorage);
            else if (memoryStorage.InterfaceType.Equals(new MemoryStorageInterfaces("SATA")))
                _sataMemoryStorages.Add(memoryStorage);

            _memoryStorages.Add(memoryStorage);

            TotalPowerConsumption += memoryStorage.Power;
            return this;
        }

        public IComputerBuilder WithWifiAdapter(WiFiAdapter? wiFiAdapter)
        {
            if (wiFiAdapter is null)
                ArgumentNullException.ThrowIfNull(wiFiAdapter);

            new WifiModuleCompatibilityValidator(wiFiAdapter).ValidateWifiModuleCompatibility(Motherboard);

            WiFiAdapter = wiFiAdapter;
            TotalPowerConsumption += WiFiAdapter.Power;
            return this;
        }

        public IComputerBuilder WithPsu(Psu psu)
        {
            Psu = psu ?? throw new ArgumentNullException(nameof(psu));
            return this;
        }

        public IComputer Build()
        {
            if (ComputerCase is null || Motherboard is null || Cpu is null || CoolingSystem is null || Psu is null)
            {
                throw new PcAssemblyException("Missing key PC parts");
            }

            new SystemCompatibilityValidator(this).ValidateSystemCompatibility();

            return new PersonalComputer(
                ComputerCase,
                Motherboard,
                Cpu,
                CoolingSystem,
                _drams,
                _gpus,
                _memoryStorages,
                WiFiAdapter,
                TotalPowerConsumption,
                Psu);
        }
    }
}