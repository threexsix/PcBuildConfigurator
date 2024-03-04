using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards;

public class Bios
{
    private readonly List<CpuBase> _cpuBases;
    public Bios(IEnumerable<CpuBase> supportedCpuBases)
    {
        if (supportedCpuBases == null)
            throw new ArgumentNullException(nameof(supportedCpuBases));

        _cpuBases = new List<CpuBase>(supportedCpuBases);
    }

    public ICollection<CpuBase> SupportedCpuBases => _cpuBases;
}