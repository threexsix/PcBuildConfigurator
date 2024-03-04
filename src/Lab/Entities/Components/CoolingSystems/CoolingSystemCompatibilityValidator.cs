using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ComputerCases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CPUs;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CoolingSystems;

public class CoolingSystemCompatibilityValidator
{
    private readonly CoolingSystem _coolingSystem;

    public CoolingSystemCompatibilityValidator(CoolingSystem coolingSystem)
    {
        _coolingSystem = coolingSystem ?? throw new ArgumentNullException(nameof(coolingSystem));
    }

    public void ValidateCoolingSystemCompatibility(ICpu? cpu, ComputerCase? computerCase)
    {
        if (cpu is null)
            throw new PrerequisitesViolationException("Processor should be installed before cooling system");

        if (computerCase is null)
            throw new PrerequisitesViolationException("Case should be installed before cooling system");

        if (_coolingSystem.Sockets.All(x => !x.Equals(cpu.Socket)))
            throw new MismatchAssemblyException("Wrong socket between processor and cooling system");

        if (_coolingSystem.TowerHeight > computerCase.MaxHeight)
            throw new MismatchAssemblyException("Cooling System is not fitting PC case");

        if (_coolingSystem.MaxTdp < cpu.Tdp)
            throw new GuaranteeException("Cooling system tdp is lower than cpu tdp");
    }
}