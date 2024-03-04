using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CPUs;

public class CpuCompatibilityValidator
{
    private readonly ICpu _cpu;

    public CpuCompatibilityValidator(ICpu cpu)
    {
        _cpu = cpu ?? throw new ArgumentNullException(nameof(cpu));
    }

    public void ValidateCpuCompatibility(Motherboard? motherboard)
    {
        if (motherboard is null)
            throw new PrerequisitesViolationException("Motherboard should be installed before processor");

        if (!motherboard.Socket.Equals(_cpu.Socket))
            throw new MismatchAssemblyException("Wrong socket between processor and motherboard");

        if (motherboard.Bios.SupportedCpuBases.All(motherboardCpuBase => !motherboardCpuBase.Equals(_cpu.CpuBase)))
            throw new MismatchAssemblyException("Bios is not supporting that cpu");
    }
}