using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CPUs;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerSystems;

public class SystemCompatibilityValidator
{
    private readonly PersonalComputer.PersonalComputerBuilder _computerBuilder;

    public SystemCompatibilityValidator(PersonalComputer.PersonalComputerBuilder computerBuilder)
    {
        _computerBuilder = computerBuilder ?? throw new ArgumentNullException(nameof(computerBuilder));
    }

    public void ValidateSystemCompatibility()
    {
        if (_computerBuilder.ComputerCase is null || _computerBuilder.Motherboard is null ||
            _computerBuilder.Cpu is null || _computerBuilder.Drams.Count == 0 ||
            _computerBuilder.MemoryStorages.Count == 0 ||
            (_computerBuilder.Gpus.Count == 0 && _computerBuilder.Cpu is not GraphicIntegratedCpu))
            throw new PcAssemblyException("Missing key PC components");

        if (_computerBuilder.Psu != null && _computerBuilder.TotalPowerConsumption > _computerBuilder.Psu.Power)
            throw new PcAssemblyException("Not enough power to run the system");
    }
}